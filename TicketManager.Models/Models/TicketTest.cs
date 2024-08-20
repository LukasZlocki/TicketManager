using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class TicketTest
    {
        [Key]
        public int TicketTestId { get; set; }
        public ICollection<TicketTestParameter>? TicketTestParameters { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}