using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReaderingBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderingBlog.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "4A536E31-EB55-4652-A7FF-297E7C692867",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "79C11C37-7A5D-46CB-B491-851E5E82725D",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "4A536E31-EB55-4652-A7FF-297E7C692867",
                UserId = "79C11C37-7A5D-46CB-B491-851E5E82725D"
            });






            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "A3D5C97B-82CB-4ABD-8B76-98EB5C6FA83D",
                Name = "user",
                NormalizedName = "USER"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "0C7E2AC1-22D2-4356-84DA-80986AFE0B87",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "my1@email.com",
                NormalizedEmail = "MY1@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "A3D5C97B-82CB-4ABD-8B76-98EB5C6FA83D",
                UserId = "0C7E2AC1-22D2-4356-84DA-80986AFE0B87"
            });











            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("D44378E7-3E17-4DC7-8CA5-13986CC4D3CF"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ECC37F52-5903-4F80-9F61-2F795ECE1897"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("579AD3DC-4CA6-4799-B625-D7E67E02876A"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
