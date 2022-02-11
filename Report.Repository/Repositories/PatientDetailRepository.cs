using Microsoft.AspNetCore.Mvc;
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
    public class PatientDetailRepository : IPatientDetailRepository
    {
        private readonly DBContext _dbContext;
        private IConfiguration _iconfiguration;
        public PatientDetailRepository(DBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _iconfiguration = configuration;
        }
        /// <summary>
        /// To Display the all patient details
        /// </summary>
        /// <returns></returns>
        public List<PatientDetailsModel> GetPatientDetails()
        {
            var patientDetails = new List<PatientDetailsModel>();
            try
            {
                patientDetails = (from patient in _dbContext.PatientDetails
                                  select new PatientDetailsModel
                                  {
                                      PatientId = patient.PatientId,
                                      PatientName = patient.PatientName,
                                      DOB = patient.DOB,
                                      Gender = patient.Gender,
                                      Address = patient.Address,
                                      City = patient.City,
                                      State = patient.State,
                                      PostalCode = patient.PostalCode,
                                      Country = patient.Country,
                                      Phone = patient.Phone,
                                  }).ToList();

            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return patientDetails;

        }
        /// <summary>
        /// To display the patient details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PatientDetailsModel GetPatientDetails(long Id)
        {
            var patientDetails = new PatientDetailsModel();
            try
            {
                patientDetails = (from patient in _dbContext.PatientDetails
                                  where patient.PatientId == Id
                                  select new PatientDetailsModel
                                  {
                                      PatientId = patient.PatientId,
                                      PatientName = patient.PatientName,
                                      DOB =patient.DOB,
                                      Gender = patient.Gender,
                                      Address = patient.Address,
                                      City = patient.City,
                                      State = patient.State,
                                      PostalCode = patient.PostalCode,
                                      Country = patient.Country,
                                      Phone = patient.Phone,
                                  }).FirstOrDefault() ?? new PatientDetailsModel();
            }
            catch (Exception ex)
            {
                //To write the error message in text
                var loggers = new Loggers(_iconfiguration);
                loggers.WriteLog(ex.Message.ToString());
            }
            return patientDetails;
        }
        /// <summary>
        /// Add the patient details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResponseMessage AddPatientDetails(PatientDetailsModel model)
        {
            try
            {
                var exist = _dbContext.PatientDetails.Find(model.PatientId);
                if (exist != null)
                {
                    return new HttpResponseMessage(HttpStatusCode.Found);
                }

                PatientDetails patientDetails = new PatientDetails()
                {
                    PatientId = model.PatientId,
                    PatientName = model.PatientName,
                    DOB = model.DOB,
                    Gender = model.Gender,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Country = model.Country,
                    PostalCode = model.PostalCode,
                    Phone = model.Phone,
                };
                _dbContext.PatientDetails.Add(patientDetails);
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
        /// Update the patient details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HttpResponseMessage ModifyPatientDetails(PatientDetailsModel model)
        {
            try
            {
                var exist = _dbContext.PatientDetails.Find(model.PatientId);
                if (exist == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                PatientDetails patientDetail = new PatientDetails()
                {
                    PatientId = model.PatientId,
                    PatientName = model.PatientName,
                    DOB = model.DOB,
                    Gender = model.Gender,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Country = model.Country,
                    PostalCode = model.PostalCode,
                    Phone = model.Phone,
                };

                var local = _dbContext.Set<PatientDetails>().Local.FirstOrDefault(entry => entry.PatientId.Equals(model.PatientId));
                // check if local is not null 
                if (local != null)
                {
                    // detach
                    _dbContext.Entry(local).State = EntityState.Detached;
                }
                // set Modified model in your entry
                _dbContext.Entry(patientDetail).State = EntityState.Modified;
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
        /// Delete the patient details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HttpResponseMessage DeletePatientDetails(long Id)
        {
            try
            {
                var patientDetails = _dbContext.PatientDetails.Find(Id);
                if (patientDetails == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                _dbContext.PatientDetails.Remove(patientDetails);
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
