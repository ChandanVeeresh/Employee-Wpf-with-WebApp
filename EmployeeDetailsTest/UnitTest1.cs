using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using WPFwebApi;
using StudentDetailsServiceLayer;
using StudentDetailsServiceLayer.Models;
using StudentDetailsServiceLayer.Controllers;
using System.Collections.Generic;
using WPFwebApi;

namespace EmployeeDetailsTest
{
    [TestClass]
    public class UnitTest1
    {
        //test methods for client side
        public static bool Employeetesting(string firstName, string lastName, string email, string address)
        {

            return VerifyEmployeeDetails.verify(firstName, lastName, email, address);
        }

        public static bool EmployeetestingServer(string firstName, string lastName, string email, string address)
        {

            return EmployeeDetailVerifier.verify(firstName, lastName, email, address);
        }

        [TestMethod]
        public void ValidInputs_OnCreatingEmployee_ReturnsTrue()
        {
            Assert.AreEqual(true, Employeetesting("Chandan", "Veeresh", "mrchandana@gmail.in", "SJCE MYSORE"));
        }
        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void InValidEmail_OnCreatingEmployee_ThrowsInvalidInputException()
        {
            Employeetesting("Chandan", "Veeresh", "mrchandanav", "SJCE MYSORE");
        }

        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void EmptyFirstName_OnCreating_ThrowsInvalidInputException()
        {
            Employeetesting("", "Veeresh", "mrchandanav@gmail.com", "SJCE MYSORE");
        }
        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void EmptyLastName_OnCreating_ThrowsInvalidInputException()
        {
            Employeetesting("Chandan", "", "mrchandanav@gmail.com", "SJCE MYSORE");
        }



        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void EmptyEmailId_OnCreating_ThrowsInvalidInputException()
        {
            Employeetesting("Chandan", "Veeresh", "", "SJCE MYSORE");
        }

        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void EmptyAddress_OnCreating_ThrowsInvalidInputException()
        {
            Employeetesting("Chandan", "Veeresh", "mrchandanav@gmail.com", "");
        }


        //test methods for server side

        [TestMethod]
        public void ValidInputs_OnCreatingEmployee_ReturnsTrue_SERVER()
        {
            Assert.AreEqual(true, EmployeetestingServer("Chandan", "Veeresh", "mrchandana@gmail.in", "SJCE MYSORE"));
        }
        [TestMethod, ExpectedException(typeof(InvalidException))]
        public void InValidEmail_OnCreatingEmployee_ThrowsInvalidInputException_SERVER()
        {
            EmployeetestingServer("Chandan", "Veeresh", "mrchandanav", "SJCE MYSORE");
        }

        [TestMethod, ExpectedException(typeof(InvalidException))]
        public void EmptyFirstName_OnCreating_ThrowsInvalidInputException_SERVER()
        {
            EmployeetestingServer("", "Veeresh", "mrchandanav@gmail.com", "SJCE MYSORE");
        }
        [TestMethod, ExpectedException(typeof(InvalidException))]
        public void EmptyLastName_OnCreating_ThrowsInvalidInputException_SERVER()
        {
            EmployeetestingServer("Chandan", "", "mrchandanav@gmail.com", "SJCE MYSORE");
        }



        [TestMethod, ExpectedException(typeof(InvalidException))]
        public void EmptyEmailId_OnCreating_ThrowsInvalidInputException_SERVER()
        {
            EmployeetestingServer("Chandan", "Veeresh", "", "SJCE MYSORE");
        }

        [TestMethod, ExpectedException(typeof(InvalidException))]
        public void EmptyAddress_OnCreating_ThrowsInvalidInputException_SERVER()
        {
            EmployeetestingServer("Chandan", "Veeresh", "mrchandanav@gmail.com", "");
        }
        
    }
}
