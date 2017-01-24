using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDetailsServiceLayer.Models;

namespace StudentDetailsServiceLayer.Controllers
{
    public class EmployeeController : ApiController
    {
        static readonly IEmployeeRepository employeeRepository = new EmployeeRepository();

        public EmployeeController()
        {
         
        }

        public HttpResponseMessage GetAll()
        {
            List<DB_Employee> empList = employeeRepository.GetAll().ToList();
            return Request.CreateResponse<List<DB_Employee>>(HttpStatusCode.OK, empList);
        }

        public HttpResponseMessage Get(int id)
        {
            DB_Employee employee = employeeRepository.Get(id);
            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Employee Not found for the Given ID");
            }

            else
            {
                return Request.CreateResponse<DB_Employee>(HttpStatusCode.OK, employee);
            }
        }


        public HttpResponseMessage Post(DB_Employee employee)
        {
            EmployeeDetailVerifier obj = new EmployeeDetailVerifier();
            if (obj.InsertEmployee(employee)==0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please fill all the details");

            }
           
                return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(DB_Employee employee)
        {
            EmployeeDbDataContext connection = new EmployeeDbDataContext();
            DB_Employee obj = (from s in connection.DB_Employees where s.EmployeeId == employee.EmployeeId select s).FirstOrDefault();
            employee.Email = obj.Email;
            EmployeeDetailVerifier obj1 = new EmployeeDetailVerifier();

            if (obj1.UpdateEmployee(employee)==0)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");

            if (!employeeRepository.Update(employee))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
     

        public HttpResponseMessage Delete(int id)
        {
            employeeRepository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
