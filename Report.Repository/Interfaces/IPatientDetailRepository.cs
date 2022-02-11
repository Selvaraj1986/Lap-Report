using Microsoft.AspNetCore.Mvc;
using Report.Entity.DBContextModel;
using Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Interfaces
{
    public interface IPatientDetailRepository
    {
        /// <summary>
        /// To display the all patient details
        /// </summary>
        /// <returns></returns>
        List<PatientDetailsModel> GetPatientDetails();
        /// <summary>
        /// To display the patient by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PatientDetailsModel GetPatientDetails(long Id);
        /// <summary>
        /// Add the patient details
        /// </summary>
        /// <param name="patientDetails"></param>
        /// <returns></returns>
        HttpResponseMessage AddPatientDetails(PatientDetailsModel patientDetails);
        /// <summary>
        /// Update the patient details
        /// </summary>
        /// <param name="patientDetails"></param>
        /// <returns></returns>
        HttpResponseMessage ModifyPatientDetails(PatientDetailsModel patientDetails);
        /// <summary>
        /// Delete the patient details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        HttpResponseMessage DeletePatientDetails(long Id);
    }
}
