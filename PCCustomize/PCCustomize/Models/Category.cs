using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCCustomize.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsDel { get; set; }
        public ICollection<Component> Components { get; set; }
    }
}