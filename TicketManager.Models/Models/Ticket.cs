using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [StringLength(100)]
        public string? RequestorEmail { get; set; }
        public DateTime ImplementedAt { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public ICollection<TicketTest>? TicketTests { get; set; }

        public int DepartmentId { get; set; }
        public Department? RequestorDepartment { get; set; }

        public int LabLocationId { get; set; }
        public LabLocation? LabLocation { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int TicketStatusId { get; set; }
        public TicketStatus? TicketStatus { get; set; }
    }
}