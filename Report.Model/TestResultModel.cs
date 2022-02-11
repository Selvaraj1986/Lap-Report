using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class TestResultModel
    {
        public long ResultId { get; set; }
        public long PatientId { get; set; }
        public long TypeId { get; set; }
        public List<TestSummaryModel> TestSummary { get; set; } = null!;
    }
}
