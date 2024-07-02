using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    class Test
    {
        [Key]
        public int TestId { get; set; }
        [StringLength(30)]
        public string? TestDescription { get; set; }
        [StringLength(10)]
        public string? TestUnits { get; set; }
    }
}
