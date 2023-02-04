using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class UserHistory
    {
        public int userHistoryID { get; set; }
        public DateTime userCreationDate { get; set; }
        public DateTime userLastLogin { get; set; }
        public int userID { get; set; }
    }
}
