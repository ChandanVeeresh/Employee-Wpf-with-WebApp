using StudentDetailsServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDetailsServiceLayer
{
    public class InvalidException : System.Exception
    {
        public InvalidException(string s) : base(s)
        {
        }

    }
    public class EmployeeDetailVerifier
    {
        private readonly IEmployeeRepository _emp;
        public EmployeeDetailVerifier()
        {
            _emp = new EmployeeRepository();
        }

        public EmployeeDetailVerifier(IEmployeeRepository employee) {
            if(employee!=null)
            _emp = employee;
        }
        public IEnumerable<DB_Employee> GetAll()
        {
            return _emp.GetAll();
        }

        public DB_Employee Get(int EmployeeID)
        {
            return _emp.Get(EmployeeID);
        }

        public int InsertEmployee(DB_Employee newEmployee)
        {
            verify(newEmployee.FirstName,newEmployee.LastName,newEmployee.Email,newEmployee.Address);
            var status = _emp.Add(newEmployee);
            if (status == true)
                return 1;
            else
                return 0;
        }

        public int UpdateEmployee(DB_Employee updateEmployee) {

            if (verify(updateEmployee.FirstName, updateEmployee.LastName, updateEmployee.Email, updateEmployee.Address))
                return 1;
            else
                return 0;

        }

        public static bool verify(string firstName, string lastName, string email, string address)
        {
            string error = "";
            if (string.IsNullOrEmpty(firstName))
                error += "First Name cannot be empty \n";
            if (string.IsNullOrEmpty(lastName))
                error += "Last Name Cannot be empty\n";
            if (string.IsNullOrEmpty(email))
                error += "Email id cannot be empty \n";
            if (string.IsNullOrEmpty(address))
                error += "Address cannot be empty \n";
            if (error != "")
            {
                throw (new InvalidException(error));
            }
            IsValidEmail(email);

            return true;

        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                throw (new InvalidException("Invalid Email Id"));
            }
        }
    }
}