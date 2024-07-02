using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    class ProductDisplacement
    {
        [Key]
        public int ProductDisplacementId { get; set; }
        public int Displacement { get; set; }
        public int ProductId { get; set; }
    }
}
