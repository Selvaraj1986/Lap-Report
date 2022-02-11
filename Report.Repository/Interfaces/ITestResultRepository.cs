using Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Interfaces
{
    public interface ITestResultRepository
    {
        /// <summary>
        /// To display the test result
        /// </summary>
        /// <returns></returns>
        List<TestResultModel> GetTestResult();
        /// <summary>
        /// To display the test result details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TestResultModel GetTestResult(long Id);
        /// <summary>
        /// Add the test result details
        /// </summary>
        /// <param name="testResultModel"></param>
        /// <returns></returns>
        HttpResponseMessage AddTestResult(TestResultModel testResultModel);
        /// <summary>
        /// Update the test result details
        /// </summary>
        /// <param name="testResultModel"></param>
        /// <returns></returns>
        HttpResponseMessage ModifyTestResult(TestResultModel testResultModel);
        /// <summary>
        /// Delete test result by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        HttpResponseMessage DeleteTestResult(long Id);
    }
}
