using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDetailsServiceLayer.Models;
using WPFwebApi;

namespace StudentDetailsServiceLayer.Controllers
{
    public class EmployeeController : ApiController
    {
        static readonly IEmployeeRepository employeeRepository = new EmployeeRepository();

        public HttpResponseMessage GetAllEmployees()
        {
            List<DB_Employee> empList = employeeRepository.GetAll().ToList();
            return Request.CreateResponse<List<DB_Employee>>(HttpStatusCode.OK, empList);
        }

        public HttpResponseMessage GetEmplopyee(int id)
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


        public HttpResponseMessage PostEmployee(DB_Employee employee)
        {
            if (String.IsNullOrEmpty(employee.FirstName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please fill all the details");

            }
            bool result = employeeRepository.Add(employee);
            if (result)
            {
                var response = Request.CreateResponse<DB_Employee>(HttpStatusCode.Created, employee);
                string uri = Url.Link("DefaultApi", new { id = employee.EmployeeId });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "");
            }
        }

        public HttpResponseMessage PutEmployee(DB_Employee employee)
        {
           
            if (!employeeRepository.Update(employee))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage PutEmployee(int id,DB_Employee employee)
        {
            employee.EmployeeId = id;
            if (!employeeRepository.Update(employee))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        public HttpResponseMessage DeleteProduct(int id)
        {
            employeeRepository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
