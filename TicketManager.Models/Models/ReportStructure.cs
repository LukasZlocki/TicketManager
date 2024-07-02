using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    class ReportStructure
    {
        [Key]
        public int ReportStructureId { get; set; }
        [StringLength(100)]
        public int FolderDescription { get; set; }

        public int ReportTypeId { get; set; }
    }
}
