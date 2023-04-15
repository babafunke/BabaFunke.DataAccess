using BabaFunke.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace Babafunke.DataAccessDemo.Models
{
    public class Product : IPrimaryKey
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Count { get; set; }

        public bool IsDisabled { get; set; }


        public DateTime DateAdded { get; }

        public Product()
        {
            DateAdded = DateTime.Now;
        }
    }
}
