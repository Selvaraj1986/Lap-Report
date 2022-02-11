using Microsoft.Extensions.Configuration;
using Report.Entity;
using Report.Model;
using Report.Repository.Interfaces;
using Report.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Repositories
{
    public class GenerateReportRepository : IGenerateReportRepository
    {

        private readonly DBContext _dbContext;
        private IConfiguration _iconfiguration;
        public GenerateReportRepository(DBContext dbContext, IConfiguration iconfiguration)
        {
            _dbContext = dbContext;
            _iconfiguration = iconfiguration;

        }
        /// <summary>
        /// To display the all reports
        /// </summary>
        /// <returns></returns>
        public List<GenerateReportModel> GetGenerateReports()
        {
            var reportModel = new List<GenerateReportModel>();
            try
            {
                reportModel = (from report in _dbContext.TestReport
                               join patient in _dbContext.PatientDetails on report.PatientId equals patient.PatientId
                               select new GenerateReportModel
                               {
                                   ReportId = report.ReportId,
                                   ReportName = report.ReportName,
                                   ReportDate = ExtensionMethods.ToDateFormat(report.ReportDate.ToString() ?? string.Empty),
                                   ReportStatus = report.ReportStatus,
                                   PatientId = report.PatientId,
                                   PatientName = patient.PatientName,
                                   DescriptionSummary = report.DescriptionSummary,
                                   typeOfTestCollections = (from type in _dbContext.TypeOfTest
                                                            where type.PatientId == patient.PatientId
                                                            select new TypeOfTestCollection
                                                            {
                                                                TypeId = type.TypeId,
                                                                TypeName = type.TestName,
                                                                EnteredDate = ExtensionMethods.ToDateFormat(type.EnteredDate.ToString() ?? string.Empty),
                                                                TimeOfTest = ExtensionMethods.ToTimeFormat(type.EnteredDate.ToString() ?? string.Empty),
                                                                testResultCollections = (from result in _dbContext.TestResult
                                                                                         where result.TypeId == type.TypeId && result.PatientId == patient.PatientId
                                                                                         select new TestResultCollection
                                                                                         {
                                                                                             ResultId = result.ResultId,
                                                                                             resultDetailsCollections = (from detail in _dbContext.TestSummary
                                                                                                                         where detail.ResultId == result.ResultId
                                                                                                                         select new ResultDetailsCollection
                                                                                                                         {
                                                                                                                             DetailId = detail.DetailId,
                                                                                                                             Test = detail.Test,
                                                                                                                             Result = detail.Result
                                                                                                                         }).ToList(),
                                                                                         }).FirstOrDefault() ?? new TestResultCollection(),
                                                            }).ToList(),
                               }

                     ).ToList();


            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return reportModel;
        }
        /// <summary>
        /// To display the report by datetime range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<GenerateReportModel> GetGenerateReports(DateTime startDate, DateTime endDate)
        {
            var reportModel = new List<GenerateReportModel>();
            try
            {
                reportModel = (from report in _dbContext.TestReport
                               where report.ReportDate >= startDate && report.ReportDate <= endDate
                               join patient in _dbContext.PatientDetails on report.PatientId equals patient.PatientId
                               select new GenerateReportModel
                               {
                                   ReportId = report.ReportId,
                                   ReportName = report.ReportName,
                                   ReportDate = ExtensionMethods.ToDateFormat(report.ReportDate.ToString() ?? string.Empty),
                                   ReportStatus = report.ReportStatus,
                                   PatientId = report.PatientId,
                                   PatientName = patient.PatientName,
                                   DescriptionSummary = report.DescriptionSummary,
                                   typeOfTestCollections = (from type in _dbContext.TypeOfTest
                                                            where type.PatientId == patient.PatientId
                                                            select new TypeOfTestCollection
                                                            {
                                                                TypeId = type.TypeId,
                                                                TypeName = type.TestName,
                                                                EnteredDate = ExtensionMethods.ToDateFormat(type.EnteredDate.ToString() ?? string.Empty),
                                                                TimeOfTest = ExtensionMethods.ToTimeFormat(type.EnteredDate.ToString() ?? string.Empty),
                                                                testResultCollections = (from result in _dbContext.TestResult
                                                                                         where result.TypeId == type.TypeId && result.PatientId == patient.PatientId
                                                                                         select new TestResultCollection
                                                                                         {
                                                                                             ResultId = result.ResultId,
                                                                                             resultDetailsCollections = (from detail in _dbContext.TestSummary
                                                                                                                         where detail.ResultId == result.ResultId
                                                                                                                         select new ResultDetailsCollection
                                                                                                                         {
                                                                                                                             DetailId = detail.DetailId,
                                                                                                                             Test = detail.Test,
                                                                                                                             Result = detail.Result
                                                                                                                         }).ToList(),
                                                                                         }).FirstOrDefault() ?? new TestResultCollection(),
                                                            }).ToList(),
                               }

                    ).ToList();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return reportModel;
        }
    }
}
