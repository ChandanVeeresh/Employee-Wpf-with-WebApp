using StudentDetailsServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFwebApi
{
   public  class AddEmployeeViewModel 
    {

        HttpClient client;
        public AddEmployeeViewModel(HttpClient client) {
            this.client = client;
            Activate = true;
            addEmployee = new Command(OnAddEmployeeBtn_Click);
        }
        private bool _acticvate;
        public bool Activate
        {
            get { return _acticvate; }
            set
            {
                _acticvate = value;
            }
        }


        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

       

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

      

        private string _address;


        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

     

        public ICommand addEmployee
        {
            get; set;
        }


        public async void OnAddEmployeeBtn_Click()
        {
            try
            {
                VerifyEmployeeDetails.verify(FirstName, LastName, Email, Address);

                DB_Employee objEmployee = new DB_Employee();
                objEmployee.FirstName = FirstName;
                objEmployee.LastName = LastName;
                objEmployee.Email = Email;
                objEmployee.Address = Address;

                if (Activate) 
                    objEmployee.Status = "Activated";
                else
                    objEmployee.Status = "Deactivated";

                var response = await client.PostAsJsonAsync("/api/employee/", objEmployee);
                response.EnsureSuccessStatusCode(); 
                MessageBox.Show("Employee Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (InvalidInputException e)
            {
                MessageBox.Show("Error \n" + e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Employee not Added", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
