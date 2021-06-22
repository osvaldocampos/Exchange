using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Data.Models
{
    public class Transaction
    {
        public long TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int CurrencyTypeId { get; set; }        

        #region Navigation properties
        public virtual UserTransaction UserTransaction { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }
        #endregion
    }
}
