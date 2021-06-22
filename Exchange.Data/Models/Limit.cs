using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Data.Models
{
    public class Limit
    {
        public int LimitId { get; set; }
        public int CurrencyTypeId { get; set; }
        public decimal Amount { get; set; }

        #region Navigation properties
        public virtual UserLimit UserLimit { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }
        #endregion
    }
}
