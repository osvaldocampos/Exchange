using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Data.Models
{
    public class UserTransaction
    {
        public int UserId { get; set; }
        public long TransactionId { get; set; }

        #region Navigation properties
        public virtual User User { get; set; }
        public virtual Transaction Transaction { get; set; }
        #endregion
    }
}
