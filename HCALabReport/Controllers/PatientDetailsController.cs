using Microsoft.AspNetCore.Mvc;
using Report.Model;
using Report.Repository.Interfaces;
using System.Net;

namespace HCALabReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : Controller
    {
        private readonly IPatientDetailRepository _patientDetailRepository;

        public PatientDetailsController(IPatientDetailRepository patientDetailRepository)
        {
            _patientDetailRepository = patientDetailRepository;
        }
        /// <summary>
        /// To display all the patient details
        /// </summary>
        /// <returns></returns>
        [Route("GetPatientDetails")]
        [HttpGet]
        public ActionResult GetPatientDetails()
        {
            var result = _patientDetailRepository.GetPatientDetails();
            return this.Ok(result);
        }
        /// <summary>
        /// To display the patient details by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetPatientDetailById")]
        [HttpGet]
        public ActionResult GetPatientDetailById(long Id)
        {
            var result = _patientDetailRepository.GetPatientDetails(Id);
            return this.Ok(result);
        }
        /// <summary>
        /// Add the patient details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddPatientDetails")]
        [HttpPost]
        public HttpResponseMessage AddPatientDetails(PatientDetailsModel model)
        {
            var status = _patientDetailRepository.AddPatientDetails(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Update the patient details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("ModifyPatientDetails")]
        [HttpPut]
        public HttpResponseMessage ModifyPatientDetails(PatientDetailsModel model)
        {
            var status = _patientDetailRepository.ModifyPatientDetails(model);
            return new HttpResponseMessage(status.StatusCode);
        }
        /// <summary>
        /// Delete the patient details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeletePatientDetails")]
        [HttpDelete]
        public HttpResponseMessage DeletePatientDetails(long Id)
        {
            var status = _patientDetailRepository.DeletePatientDetails(Id);
            return new HttpResponseMessage(status.StatusCode);
        }
    }
}
