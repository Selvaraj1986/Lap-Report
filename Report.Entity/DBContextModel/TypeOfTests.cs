using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Entity.DBContextModel
{
    public class TypeOfTests
    {
        [Key]
        public long TypeId { get; set; }

        public long PatientId { get; set; }
        public string? TestName { get; set; }
        public bool? IsTest { get; set; }

        public DateTime? EnteredDate { get; set; }
    }
}
