using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreFirst.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool IsYoungDriver { get; set; }
    }
}
