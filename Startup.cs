using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReaderingBlog.Domain;
using ReaderingBlog.Domain.Repositories.Abstract;
using ReaderingBlog.Domain.Repositories.EntityFramework;
using ReaderingBlog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReaderingBlog
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;


        public void ConfigureServices(IServiceCollection services)
        {

            #region Подключаем конфигурацию из appsetting.json

            Configuration.Bind("Project", new Config());
            Configuration.Bind("AuthenticationFacebook", new Config());
            Configuration.Bind("AuthenticationVK", new Config());

            #endregion

            #region Подключаем нужный функционал приложения в качестве сервисов

            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            #endregion

            #region Подключаем контекст БД

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            #endregion

            #region Настраиваем identity систему

            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                //opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            #endregion

            #region Настраиваем аутентификацию cookie

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/home/accessdenied";
                options.SlidingExpiration = true;
            });

            #endregion


            #region Настраиваем авторизация

            services.AddAuthentication()
                .AddFacebook(config =>
                {
                    config.AppId = Config.Facebook.AppId;
                    config.AppSecret = Config.Facebook.AppSecret;
                })
                .AddOAuth("VK", "VKontakte", config =>
                {
                    config.ClientId = Config.VK.AppId;
                    config.ClientSecret = Config.VK.AppSecret;
                    config.ClaimsIssuer = "VKontakte";
                    config.CallbackPath = new PathString("/signin-vkontakte-token");
                    config.AuthorizationEndpoint = "https://oauth.vk.com/authorize";
                    config.TokenEndpoint = "https://oauth.vk.com/access_token";
                    config.Scope.Add("email");
                    config.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user_id");
                    config.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                    config.SaveTokens = true;
                    config.Events = new OAuthEvents
                    {
                        OnCreatingTicket = context =>
                        {
                            context.RunClaimActions(context.TokenResponse.Response.RootElement);
                            return Task.CompletedTask;
                        },
                        OnRemoteFailure = OnFailure
                    };
                });

            #endregion

            #region Настраиваем политику авторизации для Admin area

            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            #endregion


            #region Добавляем сервисы для контроллеров и представлений (MVC)

            services.AddControllersWithViews(x =>
            {
                //x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            });

            #endregion

        }


        private Task OnFailure(RemoteFailureContext arg)
        {
            return Task.CompletedTask;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region IsDevelopment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            #endregion

            #region Добавляем перенаправление HTTP-запроссов на HTTPS

            app.UseHttpsRedirection();

            #endregion

            #region Подключаем поддержку статичных файлов в приложении

            app.UseStaticFiles();

            #endregion

            #region Подключаем систему маршутизации

            app.UseRouting();

            #endregion



            #region Подключаем утентификацию и авторизацию

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            #endregion

            #region Регистрируем нужные нам маршуты (ендпоинты)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "admin", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            #endregion

        }
    }

}
