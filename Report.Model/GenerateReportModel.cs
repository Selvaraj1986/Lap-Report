using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class GenerateReportModel
    {
        public long ReportId { get; set; }

        public long PatientId { get; set; }
        public string? PatientName { get; set; }

        public string? ReportName { get; set; }
        public string? ReportStatus { get; set; }

        public string? ReportDate { get; set; }

        public string? DescriptionSummary { get; set; }
        public List<TypeOfTestCollection> typeOfTestCollections { get; set; } = null!;
    }
    public class TypeOfTestCollection
    {
        public long TypeId { get; set; }
        public string? TypeName { get; set; }
        //  public DateTime? EnteredDate { get; set; }
        public string? EnteredDate { get; set; }
        public string? TimeOfTest { get; set; }
        public TestResultCollection testResultCollections { get; set; } = null!;
    }
    public class TestResultCollection
    {
        public long ResultId { get; set; }
        public List<ResultDetailsCollection> resultDetailsCollections { get; set; } = null!;
    }
    public class ResultDetailsCollection
    {
        public long DetailId { get; set; }
        public string? Test { get; set; }
        public string? Result { get; set; }
    }

}
