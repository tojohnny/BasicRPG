﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class User
    {
        public int playerID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public List<Character> characters { get; set; }

    }
}
