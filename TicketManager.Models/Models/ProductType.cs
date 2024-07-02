using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        [StringLength(10)]
        public string? ProductTypeDesc { get; set; }
        public int ProductId { get; set; }

    }
}
