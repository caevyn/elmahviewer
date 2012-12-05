using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElmahViewer.Models
{
    public class ApplicationListModel
    {
        public IEnumerable<string> Applications { get; set; }
        public string CurrentApplication { get; set; }
    }
}