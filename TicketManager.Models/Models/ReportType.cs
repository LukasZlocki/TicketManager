using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Models.Models
{
    public class ReportType
    {
        [Key]
        public int ReportTypeId { get; set; }
        [StringLength(3)]
        public string? ReportShortType { get; set; }
        [StringLength(30)]
        public string? ReportDescription { get; set; }
    }
}