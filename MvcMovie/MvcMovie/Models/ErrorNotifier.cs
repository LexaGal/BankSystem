using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class ErrorNotifier
    {
        public string Source { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        
    }
}