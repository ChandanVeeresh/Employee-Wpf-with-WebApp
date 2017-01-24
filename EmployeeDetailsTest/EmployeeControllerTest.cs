using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentDetailsServiceLayer;
using StudentDetailsServiceLayer.Models;
using Rhino.Mocks;
using WPFwebApi;

namespace EmployeeDetailsTest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        
        [TestMethod]
        public void PostMethod_withEmptyFirstName_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.FirstName = "";
            obj1.LastName = "AV";
            obj1.Email = "chandanav@gmail.com";
            obj1.Address = "Mysore";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("First Name cannot be empty \n", e.Message);
            }
        }
        [TestMethod]
        public void PostMethod_withEmptyLastName_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.FirstName = "Chandan";
            obj1.LastName = "";
            obj1.Email = "chandanav@gmail.com";
            obj1.Address = "Mysore";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Last Name Cannot be empty\n", e.Message);
            }
        }
        [TestMethod]
        public void PostMethod_withEmptyEmail_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.FirstName = "Chandan";
            obj1.LastName = "AV";
            obj1.Email = "";
            obj1.Address = "Mysore";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Email id cannot be empty \n", e.Message);
            }
        }

        [TestMethod]
        public void PostMethod_withInvalidEmail_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.FirstName = "Chandan";
            obj1.LastName = "AV";
            obj1.Email = "chandanavgmail.com";
            obj1.Address = "Mysore";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e) {
                Assert.AreEqual("Invalid Email Id",e.Message);
            }
        }

        [TestMethod]
        public void PostMethod_withInvalidAddress_ThrowsException() {
            DB_Employee obj1 = new DB_Employee();
            obj1.FirstName = "Chandan";
            obj1.LastName = "AV";
            obj1.Email = "chandanav@gmail.com";
            obj1.Address = "Mysore";
            obj1.Status = "";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Address cannot be empty \n", e.Message);
            }

        }

        [TestMethod]
        public void PutMethod_withInvalidAddress_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.EmployeeId = 1;
            obj1.FirstName = "Chandan";
            obj1.LastName = "AV";
            obj1.Email = "chandanav@gmail.com";
            obj1.Address = "Mysore";
            obj1.Status = "";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Address cannot be empty \n", e.Message);
            }

        }

        [TestMethod]
        public void PutMethod_withEmptyEmail_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.EmployeeId = 1;
            obj1.FirstName = "Chandan";
            obj1.LastName = "AV";
            obj1.Email = "";
            obj1.Address = "Mysore";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Email id cannot be empty \n", e.Message);
            }

        }

        [TestMethod]
        public void PutMethod_withEmptyLastName_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.EmployeeId = 1;
            obj1.FirstName = "Chandan";
            obj1.LastName = "";
            obj1.Email = "chandan@gmail.com";
            obj1.Address = "Mysore";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Last Name Cannot be empty\n", e.Message);
            }

        }

        [TestMethod]
        public void PutMethod_withEmptyFirstName_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.EmployeeId = 1;
            obj1.FirstName = "";
            obj1.LastName = "AV";
            obj1.Email = "chandan@gmail.com";
            obj1.Address = "Mysore";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("First Name cannot be empty \n", e.Message);
            }

        }
        [TestMethod]
        public void PutMethod_withInavlidEmail_ThrowsException()
        {
            DB_Employee obj1 = new DB_Employee();
            obj1.EmployeeId = 1;
            obj1.FirstName = "Chandan";
            obj1.LastName = "AV";
            obj1.Email = "chandancom";
            obj1.Address = "Mysore";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            EmployeeDetailVerifier mockEmpCrtl = new EmployeeDetailVerifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid Email Id", e.Message);
            }

        }
    }
}
