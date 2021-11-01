using System;
using System.Collections.Generic;


namespace EFInClass.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}