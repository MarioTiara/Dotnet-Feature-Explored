﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public double Rating { get; set; }
    }
}
