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
    public class TestReportRepository : ITestReportRepository
    {
        private readonly DBContext _dbContext;
        private IConfiguration _iconfiguration;
        public TestReportRepository(DBContext dbContext, IConfiguration iconfiguration)
        {
            _dbContext = dbContext;
            _iconfiguration = iconfiguration;
        }
        /// <summary>
        /// To display the test reports
        /// </summary>
        /// <returns></returns>
        public List<TestReportModelView> GetTestReports()
        {
            var testReports = new List<TestReportModelView>();
            try
            {
                testReports = (from report in _dbContext.TestReport
                               select new TestReportModelView
                               {
                                   ReportId = report.ReportId,
                                   PatientId = report.PatientId,
                                   ReportName = report.ReportName,
                                   ReportStatus = report.ReportStatus,
                                   ReportDate =  ExtensionMethods.ToDateFormat(report.ReportDate.ToString() ?? string.Empty),
                                   DescriptionSummary = report.DescriptionSummary
                               }).ToList();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return testReports;

        }
        /// <summary>
        /// To display the test report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TestReportModelView GetTestReports(long Id)
        {
            var testReport = new TestReportModelView();
            try
            {
                testReport = (from report in _dbContext.TestReport
                              where report.ReportId == Id
                              select new TestReportModelView
                              {
                                  ReportId = report.ReportId,
                                  PatientId = report.PatientId,
                                  ReportName = report.ReportName,
                                  ReportStatus = report.ReportStatus,
                                  ReportDate  = ExtensionMethods.ToDateFormat(report.ReportDate.ToString() ?? string.Empty),
                                  DescriptionSummary = report.DescriptionSummary
                              }).FirstOrDefault() ?? new TestReportModelView();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return testReport;

        }
        /// <summary>
        /// add the test report details 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResponseMessage AddTestReport(TestReportModel model)
        {
            try
            {
                var exist = _dbContext.TestReport.Find(model.ReportId);
                if (exist != null)
                {
                    return new HttpResponseMessage(HttpStatusCode.Found);
                }

                TestReports testReports = new TestReports()
                {
                    ReportId = model.ReportId,
                    PatientId = model.PatientId,
                    ReportName = model.ReportName,
                    ReportStatus = model.ReportStatus,
                    ReportDate = model.ReportDate,
                    DescriptionSummary = model.DescriptionSummary
                };
                _dbContext.TestReport.Add(testReports);
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
        /// Update the test report details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResponseMessage ModifyTestReport(TestReportModel model)
        {
            try
            {
                var exist = _dbContext.TestReport.Find(model.ReportId);
                if (exist == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                TestReports testReports = new TestReports()
                {
                    ReportId = model.ReportId,
                    PatientId = model.PatientId,
                    ReportName = model.ReportName,
                    ReportStatus = model.ReportStatus,
                    ReportDate = model.ReportDate,
                    DescriptionSummary = model.DescriptionSummary
                };
                var local = _dbContext.Set<TestReports>().Local.FirstOrDefault(entry => entry.ReportId.Equals(model.ReportId));
                // check if local is not null 
                if (local != null)
                {
                    // detach
                    _dbContext.Entry(local).State = EntityState.Detached;
                }
                // set Modified model in your entry
                _dbContext.Entry(testReports).State = EntityState.Modified;
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
        /// Delete the test report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteTestReport(long Id)
        {
            try
            {
                var testReports = _dbContext.TestReport.Find(Id);
                if (testReports == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                _dbContext.TestReport.Remove(testReports);
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



