﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class Character
    {
        public int characterID { get; set; }
        public string characterName { get; set; }
        public string characterGender { get; set; }
        public string characterRace { get; set; }
        public int classID { get; set; }
        public int userID { get; set; }
        public List<CharacterHistory> history { get; set; }
        public List<Inventory> inventory { get; set; }
    }
}
