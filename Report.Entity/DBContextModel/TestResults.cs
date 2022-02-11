using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Entity.DBContextModel
{
    public class TestResults
    {
        [Key]
        public long ResultId { get; set; }
        [Required]
        public long PatientId { get; set; }
        [Required]
        public long TypeId { get; set; }
        public List<TestSummaries> TestSummaries { get; set; } = null!;
    }
}
