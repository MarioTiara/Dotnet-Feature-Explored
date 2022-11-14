using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PersonalBlog.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public static DbSet<Post> posts { get; set; }
        
        
        
    }
}
