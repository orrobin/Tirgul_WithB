using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lender:Customer
    {
        public virtual ExtendedField ExtendedField { get; set; }
    }
}
