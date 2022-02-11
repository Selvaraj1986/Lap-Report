using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class PatientDetailsModel
    {
        public long PatientId { get; set; }

        public string? PatientName { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int PostalCode { get; set; }
        public long Phone { get; set; }
    }
}
