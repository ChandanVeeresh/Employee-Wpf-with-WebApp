﻿using StudentDetailsServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFwebApi
{
    public class UpdateEmployeeViewModel
    {
        HttpClient client;
        DB_Employee updateEmp;
        public UpdateEmployeeViewModel(HttpClient client, DB_Employee SelectedEmployee) {
            this.client = client;
            UpdateBtn = new Command(OnUpdateBtn_Click);
            updateEmp = SelectedEmployee;
            FirstName = SelectedEmployee.FirstName;
            LastName = SelectedEmployee.LastName;
            Email = SelectedEmployee.Email;
            EmpID = SelectedEmployee.EmployeeId;
            Address = SelectedEmployee.Address;
            if (SelectedEmployee.Status == "Activated")
                Activate = true;
            else
                Activate = false;
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

        private int _empID;
        public int EmpID
        {
            get { return _empID; }
            set { _empID = value; }
        }

        private string _address;


        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public ICommand UpdateBtn {

            get;set;
        }
        public async void OnUpdateBtn_Click()
        {
            try
            {
                VerifyEmployeeDetails.verify(FirstName, LastName, Email, Address);
                updateEmp.FirstName = FirstName;
                updateEmp.LastName = LastName;
                updateEmp.Email = Email;
                updateEmp.Address = Address;
                updateEmp.EmployeeId = EmpID;
                if(Activate)
                    updateEmp.Status ="Activated";
                else
                    updateEmp.Status = "Deactivated";


                var response = await client.PutAsJsonAsync("/api/employee/", updateEmp);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Employee Updated Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (InvalidInputException e) {
                MessageBox.Show("Error \n"+e);

            }
            catch (Exception)
            {
                MessageBox.Show("Employee not Added ");
            }

        }

    }
}
