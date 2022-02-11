using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class TestReportModel
    {
        public long ReportId { get; set; }     
        public long PatientId { get; set; }   
        public string? ReportName { get; set; }
        public string? ReportStatus { get; set; }     
        public DateTime? ReportDate { get; set; }
        public string? DescriptionSummary { get; set; }
    }
    public class TestReportModelView
    {
        public long ReportId { get; set; }
        public long PatientId { get; set; }
        public string? ReportName { get; set; }
        public string? ReportStatus { get; set; }
        public string? ReportDate { get; set; }
        public string? DescriptionSummary { get; set; }
    }
}
