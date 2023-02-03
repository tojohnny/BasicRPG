using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class Item
    {
        public int itemID { get; set; }
        public string itemName { get; set; }
        public int inventoryID { get; set; }
        public int characterID { get; set; }
        public int userID { get; set; }
    }
}
