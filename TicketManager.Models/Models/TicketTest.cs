using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.Models.Models
{
    public class TicketTest
    {
        [Key]
        public int TicketTestId { get; set; }
        public double TestParameter { get; set; }

        public int TestId { get; set; }
        [ForeignKey("TestId")]
        public Test? Test { get; set; }

        public int TicketId { get; set; }
    }
}