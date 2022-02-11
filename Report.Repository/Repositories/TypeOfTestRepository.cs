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
    public class TypeOfTestRepository : ITypeOfTestRepository
    {

        private readonly DBContext _dbContext;
        private IConfiguration _iconfiguration;
        public TypeOfTestRepository(DBContext dbContext, IConfiguration iconfiguration)
        {
            _dbContext = dbContext;
            _iconfiguration = iconfiguration;
        }
        /// <summary>
        /// To display the type of test info
        /// </summary>
        /// <returns></returns>
        public List<TypeOfTestModelView> GetTestTypes()
        {
            var typeOfTests = new List<TypeOfTestModelView>();
            try
            {
                typeOfTests = (from type in _dbContext.TypeOfTest
                               select new TypeOfTestModelView
                               {
                                   TypeId = type.TypeId,
                                   PatientId = type.PatientId,
                                   TestName = type.TestName,
                                   IsTest = type.IsTest,
                                   EnteredDate = ExtensionMethods.ToDateFormat(type.EnteredDate.ToString() ?? string.Empty),
                                   TimeOfTest = ExtensionMethods.ToTimeFormat(type.EnteredDate.ToString() ?? string.Empty)
                               }).ToList();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }

            return typeOfTests;

        }
       /// <summary>
       /// To display the type of test info by Id
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        public TypeOfTestModelView GetTestTypes(long Id)
        {
            var typeOfTests = new TypeOfTestModelView();
            try
            {
                typeOfTests = (from type in _dbContext.TypeOfTest
                               where type.TypeId == Id
                               select new TypeOfTestModelView
                               {
                                   TypeId = type.TypeId,
                                   PatientId = type.PatientId,
                                   TestName = type.TestName,
                                   IsTest = type.IsTest,
                                   EnteredDate = ExtensionMethods.ToDateFormat(type.EnteredDate.ToString() ?? string.Empty),
                                   TimeOfTest = ExtensionMethods.ToTimeFormat(type.EnteredDate.ToString() ?? string.Empty)
                               }).FirstOrDefault() ?? new TypeOfTestModelView();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return typeOfTests;
        }
        /// <summary>
        /// Add the tye of test lis info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResponseMessage AddTestTypes(TypeOfTestModel model)
        {
            try
            {
                var exist = _dbContext.TypeOfTest.Find(model.TypeId);
                if (exist != null)
                {
                    return new HttpResponseMessage(HttpStatusCode.Found);
                }
                TypeOfTests typeOfTests = new TypeOfTests()
                {
                    TypeId = model.TypeId,
                    PatientId = model.PatientId,
                    TestName = model.TestName,
                    IsTest = model.IsTest,
                    EnteredDate = model.EnteredDate
                };
                _dbContext.TypeOfTest.Add(typeOfTests);
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
       /// Update the type of test info
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public HttpResponseMessage ModifyTestTypes(TypeOfTestModel model)
        {
            try
            {
                var exist = _dbContext.TypeOfTest.Find(model.TypeId);
                if (exist == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                TypeOfTests typeOfTests = new TypeOfTests()
                {
                    TypeId = model.TypeId,
                    PatientId = model.PatientId,
                    TestName = model.TestName,
                    IsTest = model.IsTest,
                    EnteredDate = Convert.ToDateTime(model.EnteredDate)
                };
                var local = _dbContext.Set<TypeOfTests>().Local.FirstOrDefault(entry => entry.TypeId.Equals(model.TypeId));
                // check if local is not null 
                if (local != null)
                {
                    // detach
                    _dbContext.Entry(local).State = EntityState.Detached;
                }
                // set Modified model in your entry
                _dbContext.Entry(typeOfTests).State = EntityState.Modified;
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
       /// Delete the type of the test by Id
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        public HttpResponseMessage DeleteTestTypes(long Id)
        {
            try
            {
                var typeOfTests = _dbContext.TypeOfTest.Find(Id);
                if (typeOfTests == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                _dbContext.TypeOfTest.Remove(typeOfTests);
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



