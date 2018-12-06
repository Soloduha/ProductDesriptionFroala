using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Paste { get; set; }
        public DateTime LastChanges { get; set; }
    }
}