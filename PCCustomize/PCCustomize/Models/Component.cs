using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCCustomize.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public int IsDel { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}