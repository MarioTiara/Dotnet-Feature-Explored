using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalBlog.Models
{

    [Table("post")]
    public class Post
    {
        [Key]
        public string Id { get; set; }
        public DateTime PostDatatime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
