using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class TypeOfTestModel
    {
        public long TypeId { get; set; }
        public long PatientId { get; set; }
        public string? TestName { get; set; }
        public bool? IsTest { get; set; }
        public DateTime EnteredDate { get; set; }
    }
    public class TypeOfTestModelView
    {
        public long TypeId { get; set; }
        public long PatientId { get; set; }
        public string? TestName { get; set; }
        public bool? IsTest { get; set; }
        public string? EnteredDate { get; set; }
        public string? TimeOfTest { get; set; } 
    }
}
