﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostWebApplication.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}