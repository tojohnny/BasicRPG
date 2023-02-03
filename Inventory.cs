using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class Inventory
    {
        public int inventoryID { get; set; }
        public int totalInventorySlots { get; set; }
        public int characterID { get; set; }
        public int userID { get; set; }
        public List<Item> item { get; set; }
    }
}
