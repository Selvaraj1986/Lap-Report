using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Entity.DBContextModel
{
    public class TestSummaries
    {
        [Key]
        public long DetailId { get; set; }
        [Required]
        public long ResultId { get; set; }
        public string? Test { get; set; }
        public string? Result { get; set; }
    }
}
