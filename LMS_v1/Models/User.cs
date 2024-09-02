using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_v1.Models
{
    public class User
    {
        public int uid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string role { get; set; }
        public string phone { get; set; }
        public string planID { get; set; }
        public string profileUrl { get; set; }
        public int status { get; set; }
        public DateTime expdate { get; set; }
        public int bookLimit { get; set; }
        public int isUnlimited { get; set; }
        public int subscriptionID { get; set; }
    }
}