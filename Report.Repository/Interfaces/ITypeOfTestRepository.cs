using Microsoft.AspNetCore.Mvc;
using Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Interfaces
{
    public interface ITypeOfTestRepository
    {
        /// <summary>
        /// To display the type of test
        /// </summary>
        /// <returns></returns>
        List<TypeOfTestModelView> GetTestTypes();
        /// <summary>
        /// To display the type of test by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TypeOfTestModelView GetTestTypes(long Id);
        /// <summary>
        /// Add the type of test to be take
        /// </summary>
        /// <param name="typeOfTest"></param>
        /// <returns></returns>
        HttpResponseMessage AddTestTypes(TypeOfTestModel typeOfTest);
        /// <summary>
        /// Update the type of test info
        /// </summary>
        /// <param name="typeOfTest"></param>
        /// <returns></returns>
        HttpResponseMessage ModifyTestTypes(TypeOfTestModel typeOfTest);
        /// <summary>
        /// delete the type of test info
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        HttpResponseMessage DeleteTestTypes(long Id);

    }
}
