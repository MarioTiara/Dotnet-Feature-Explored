﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Models
{
    public class PhotosModel
    {
        public int Id { get; set; } 
        public int UseId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }

    }
}
