using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginDemo.DataModel
{
    public class User
    {
        public int? ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoffTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}