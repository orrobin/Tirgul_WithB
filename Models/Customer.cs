using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class Customer
    {
        
        public int Id { get; set; }
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        [StringLength(3,MinimumLength =3)]
        [Required]
        public string Currency { get; set; }
    }
}
