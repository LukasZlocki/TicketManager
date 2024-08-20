using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string? DepartmentDescription { get; set; }

        public int FactoryLocationId { get; set; }
        public FactoryLocation? Factorylocation { get; set; }
    }
}