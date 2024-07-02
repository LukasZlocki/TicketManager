using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    class TicketStatus
    {
        [Key]
        public int TicketStatusId { get; set; }
        [StringLength(10)]
        public string? StatusDescription { get; set; }
    }
}
