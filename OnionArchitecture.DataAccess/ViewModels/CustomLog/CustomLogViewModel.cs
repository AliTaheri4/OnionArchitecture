using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.DataAccess.ViewModels.CustomLogViewModel
{
    public class CustomLogViewModel
    {
        public int? Id{ get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? EditedTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LogType { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }
        public string Message4 { get; set; }
    }
}
