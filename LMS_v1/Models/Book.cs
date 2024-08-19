using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_v1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
    }
}