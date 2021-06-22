using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Data.Models
{
    public class UserLimit
    {
        public int UserId { get; set; }
        public int LimitId { get; set; }

        #region Navigation properties
        public virtual User User { get; set; }
        public virtual Limit Limit { get; set; }
        #endregion
    }
}
