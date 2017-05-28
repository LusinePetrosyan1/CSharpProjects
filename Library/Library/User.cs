﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public User(string name, string surname, string login, string password, string type)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Type = type;
        }
    }
}
