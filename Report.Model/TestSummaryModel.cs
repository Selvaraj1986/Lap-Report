using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class TestSummaryModel
    {
        public long DetailId { get; set; }
        public long ResultId { get; set; }
        public string? Test { get; set; }
        public string? Result { get; set; }
    }
}
