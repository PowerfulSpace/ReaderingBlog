using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderingBlog.Models
{
    public class ExternalLoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string ReturnUrl { get; set; }

    }
}
