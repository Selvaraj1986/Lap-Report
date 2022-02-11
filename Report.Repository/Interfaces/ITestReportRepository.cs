using Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Interfaces
{
    public interface ITestReportRepository
    {
        /// <summary>
        /// To display the test report
        /// </summary>
        /// <returns></returns>
        List<TestReportModelView> GetTestReports();
        /// <summary>
        /// To display the test report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TestReportModelView GetTestReports(long Id);
        /// <summary>
        /// Add the test report details by Id
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        HttpResponseMessage AddTestReport(TestReportModel testReportModel);
        /// <summary>
        /// Update the test report details
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        HttpResponseMessage ModifyTestReport(TestReportModel testReportModel);
        /// <summary>
        /// Delete the report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        HttpResponseMessage DeleteTestReport(long Id);
    }
}
