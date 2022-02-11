using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Report.Entity;
using Report.Entity.DBContextModel;
using Report.Model;
using Report.Repository.Interfaces;
using Report.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Repositories
{
    public class TestResultRepository : ITestResultRepository
    {

        private readonly DBContext _dbContext;
        private IConfiguration _iconfiguration;
        public TestResultRepository(DBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _iconfiguration = configuration;
        }
        /// <summary>
        /// To display the test resuls
        /// </summary>
        /// <returns></returns>
        public List<TestResultModel> GetTestResult()
        {
            var detailsResult = new List<TestResultModel>();
            try
            {
                detailsResult = (from result in _dbContext.TestResult
                                 orderby result.ResultId
                                 select new TestResultModel
                                 {
                                     ResultId = result.ResultId,
                                     PatientId = result.PatientId,
                                     TypeId = result.TypeId,
                                     TestSummary = (from summary in _dbContext.TestSummary
                                                    where summary.ResultId == result.ResultId
                                                    select new TestSummaryModel { DetailId = summary.DetailId, ResultId = summary.ResultId, Test = summary.Test, Result = summary.Result }).ToList()

                                 }).ToList();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return detailsResult;
        }
        /// <summary>
        /// To display the test result by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TestResultModel GetTestResult(long Id)
        {
            var detailsResult = new TestResultModel();
            try
            {
                detailsResult = (from result in _dbContext.TestResult
                                 where result.ResultId == Id
                                 orderby result.ResultId
                                 select new TestResultModel
                                 {
                                     ResultId = result.ResultId,
                                     PatientId = result.PatientId,
                                     TypeId = result.TypeId,
                                     TestSummary = (from summary in _dbContext.TestSummary
                                                    where summary.ResultId == result.ResultId
                                                    select new TestSummaryModel { DetailId = summary.DetailId, ResultId = summary.ResultId, Test = summary.Test, Result = summary.Result }).ToList()

                                 }).FirstOrDefault() ?? new TestResultModel();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return detailsResult;
        }
       /// <summary>
       /// Add the test result details
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public HttpResponseMessage AddTestResult(TestResultModel model)
        {
            try
            {
                var exist = _dbContext.TestResult.Find(model.ResultId);
                if (exist != null)
                {
                    return new HttpResponseMessage(HttpStatusCode.Found);
                }

                TestResults testResults = new TestResults()
                {
                    ResultId = model.ResultId,
                    TypeId = model.TypeId,
                    PatientId = model.PatientId,
                };
                foreach (var item in model.TestSummary)
                {
                    TestSummaries testSummaries = new TestSummaries()
                    {
                        DetailId = item.DetailId,
                        ResultId = item.ResultId,
                        Test = item.Test,
                        Result = item.Result
                    };
                    _dbContext.TestSummary.Add(testSummaries);
                }
                _dbContext.TestResult.Add(testResults);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
       /// <summary>
       /// Update the test result details
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public HttpResponseMessage ModifyTestResult(TestResultModel model)
        {
            try
            {
                var exist = _dbContext.TestResult.Find(model.ResultId);
                if (exist == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                TestResults testResults = new TestResults()
                {
                    ResultId = model.ResultId,
                    TypeId = model.TypeId,
                    PatientId = model.PatientId,
                };
                foreach (var item in model.TestSummary)
                {
                    TestSummaries testSummaries = new TestSummaries()
                    {
                        DetailId = item.DetailId,
                        ResultId = item.ResultId,
                        Test = item.Test,
                        Result = item.Result
                    };
                    var localSummary = _dbContext.Set<TestSummaries>().Local.FirstOrDefault(entry => entry.DetailId.Equals(item.DetailId));
                    // check if local is not null 
                    if (localSummary != null)
                    {
                        // detach
                        _dbContext.Entry(localSummary).State = EntityState.Detached;
                    }
                    // set Modified model in your entry
                    _dbContext.Entry(testSummaries).State = EntityState.Modified;
                    // _dbContext.TestSummary.Update(testSummaries);
                }
                var local = _dbContext.Set<TestResults>().Local.FirstOrDefault(entry => entry.ResultId.Equals(model.ResultId));
                // check if local is not null 
                if (local != null)
                {
                    // detach
                    _dbContext.Entry(local).State = EntityState.Detached;
                }
                // set Modified model in your entry
                _dbContext.Entry(testResults).State = EntityState.Modified;

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        /// <summary>
        /// Delete the test result by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteTestResult(long Id)
        {
            try
            {
                var testResults = _dbContext.TestResult.Find(Id);
                if (testResults == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                _dbContext.TestResult.Remove(testResults);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}



