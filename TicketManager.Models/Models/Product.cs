using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int ProductFamilyId { get; set; }
        public ProductFamily? ProductFamily { get; set; }
    }
}