﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApp.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string FullName
        {
            get { return first_name + " " + last_name; }
        }
        public string avatar { get; set; }
    }
}
