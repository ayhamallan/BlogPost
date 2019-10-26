using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.DataModel.DataModels
{
    public class BlogPost
    {
        [Key]
        public int ID { get; set; }
        public string Auther { get; set; }
        [Required]
        public string Title { get; set; }
        public string Subtitle { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
