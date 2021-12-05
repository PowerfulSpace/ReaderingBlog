using ReaderingBlog.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderingBlog.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название публикации")]
        [Display(Name = "Название обзора")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание публикации")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание публикации")]
        public override string Text { get; set; }
        public int Rating { get; set; }

        [Display(Name = "Коментарий")]
        public List<Comment> Comments { get; set; }
    }


    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }        
        public string ImageAvatar { get; set; }
        public bool Like { get; set; }
        public bool DisLike { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }


}
