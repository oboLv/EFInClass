using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFInClass.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string Name { get; set; }
        public List<Post> Post { get; set; }
    }
}