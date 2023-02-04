using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class InventoryHistory
    {
        public int inventoryHistoryID { get; set; }
        public string inventorySlotAction { get; set; }
        public string inventorySlotModified { get; set; }
        public DateTime inventoryLastModified { get; set; }
        public int InventoryID { get; set; }
    }
}
