using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFwebApi;
namespace EmployeeDetailsTest
{
    [TestClass]
    public class UnitTest1
    {
        public static bool Employeetesting(string firstName, string lastName, string email, string address)
        {

            return VerifyEmployeeDetails.verify(firstName, lastName, email, address);
        }
        [TestMethod]
        public void ValidInputs_OnCreatingEmployee_ReturnsTrue()
        {
            Assert.AreEqual(true, Employeetesting("Chandan", "Veeresh",  "mrchandana@gmail.in", "SJCE MYSORE"));
        }
        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void InValidEmail_OnCreatingEmployee_ThrowsInvalidInputException()
        {
            Employeetesting("Chandan", "Veeresh","mrchandanav", "SJCE MYSORE");
        }

        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void EmptyFirstName_OnCreating_ThrowsInvalidInputException()
        {
            Employeetesting("", "Veeresh", "mrchandanav@gmail.com", "SJCE MYSORE");
        }
        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void EmptyLastName_OnCreating_ThrowsInvalidInputException()
        {
            Employeetesting("Chandan", "",  "mrchandanav@gmail.com", "SJCE MYSORE");
        }

       

        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void EmptyEmailId_OnCreating_ThrowsInvalidInputException()
        {
            Employeetesting("Chandan", "Veeresh",  "", "SJCE MYSORE");
        }

        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void EmptyAddress_OnCreating_ThrowsInvalidInputException()
        {
            Employeetesting("Chandan", "Veeresh","mrchandanav@gmail.com", "");
        }


    }
}
