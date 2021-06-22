using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Domain.DTOs
{
    public class TransactionDto
    {
        public long TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int CurrencyTypeId { get; set; }
    }
}
