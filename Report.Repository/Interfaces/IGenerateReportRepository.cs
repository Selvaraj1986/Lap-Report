using Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Interfaces
{
    public interface IGenerateReportRepository
    {
        /// <summary>
        /// To display the all report
        /// </summary>
        /// <returns></returns>
        List<GenerateReportModel> GetGenerateReports();
        /// <summary>
        /// To display the reports by datetime range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<GenerateReportModel> GetGenerateReports(DateTime startDate, DateTime endDate);
    }
}
