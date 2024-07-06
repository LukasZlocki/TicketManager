﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.Models.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(10)]
        public string? ProductFamilly { get; set; }

        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType? ProductType { get; set; }

        public int ProductDisplacementId { get; set; }
        [ForeignKey("ProductDisplacementId")]
        public ProductDisplacement? ProductDisplacement { get; set; }
    }
}