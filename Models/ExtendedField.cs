using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExtendedField
    {
        
        public int Id { get; set; }
        public int Rate { get; set; }
        public bool PriorApproval { get; set; }
    }
}
