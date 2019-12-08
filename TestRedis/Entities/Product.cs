using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestRedis.Enums;

namespace TestRedis.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public Status Status { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
    }
}
