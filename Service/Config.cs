using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderingBlog.Service
{
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static string CompanyName { get; set; }
        public static string CompanyEmail { get; set; }
        public static Facebooc Facebook { get; set; }
        public static VK VK { get; set; }
    }

    public class Facebooc
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }

    public class VK
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }

}
