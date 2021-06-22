using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        #region Navigation properties
        public virtual List<UserTransaction> UserTransactions { get; set; }
        public virtual List<UserLimit> UserLimits { get; set; }
        #endregion
    }
}
