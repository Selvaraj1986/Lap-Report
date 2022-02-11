using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Entity.DBContextModel
{
    public class TestReports
    {
        [Key]
        public long ReportId { get; set; }
        [Required]
        public long PatientId { get; set; }
        [Required]
        public string? ReportName { get; set; }
        public string? ReportStatus { get; set; }
        [Required]
        public DateTime? ReportDate { get; set; }
        public string? DescriptionSummary { get; set; }
    }
}
