using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StudentDetailsServiceLayer.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<DB_Employee> employees;
        EmployeeDbDataContext connection=new EmployeeDbDataContext();
        public EmployeeRepository()
        { 
        }

        public IEnumerable<DB_Employee> GetAll()
        {
            employees =(from s in connection.DB_Employees select s).ToList();
            return employees;
        }

        public DB_Employee Get(int id)
        {

            return (from s in connection.DB_Employees where s.EmployeeId == id select s).FirstOrDefault();
        }

        public bool Add(DB_Employee employee)
        {
            EmployeeDbDataContext con = new EmployeeDbDataContext();
            con.DB_Employees.InsertOnSubmit(employee);
            con.SubmitChanges();
            return true;
        }

        public void Remove(int id)
        {
            DB_Employee employee = (from s in connection.DB_Employees where s.EmployeeId == id select s).FirstOrDefault();
            if (employee.Status =="Activated")
                throw new Exception("Only deactivated Employees can be deleted");
            connection.DB_Employees.DeleteOnSubmit(employee);
            connection.SubmitChanges();
        }

        public bool Update(DB_Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("Unable to update the details of employee");
            }
            DB_Employee s = (from t in connection.DB_Employees
                     where t.EmployeeId== employee.EmployeeId
                     select t).FirstOrDefault();
            s.FirstName = employee.FirstName;
            s.LastName = employee.LastName;
            s.Status = employee.Status;
            s.Address = employee.Address;
            connection.SubmitChanges();
            return true;
        }

       
    }
}