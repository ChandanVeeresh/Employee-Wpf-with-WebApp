using StudentDetailsServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFwebApi
{
   public class LauncherViewModel : INotifyPropertyChanged
    {
        HttpClient client = new HttpClient();

        public event PropertyChangedEventHandler PropertyChanged;

        public LauncherViewModel() {
            client.BaseAddress = new Uri("http://localhost:8088");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AddEmployeeBtn = new Command(OnAddEmployeeBtn_Click);
            UpdateEmployeeBtn = new Command(OnUpdateEmployeeBtn_Click);
            DeleteEmployeeBtn = new Command(OnDeleteEmployeeBtn_Click);
            ViewEmployeeBtn = new Command(OnViewEmployeeBtn_Click);

        }

        private List<DB_Employee> employeeList;

        public List<DB_Employee> EmployeeList
        {
            get { return employeeList; }
            set
            {

                if (value != employeeList)
                {
                    employeeList = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("EmployeeList"));
                    }
                }
            }

        }


        public ICommand ViewEmployeeBtn
        {
            get; set;
        }

        public ICommand AddEmployeeBtn
        {
            get; set;
        }

        public ICommand UpdateEmployeeBtn
        {
            get; set;
        }

        public ICommand DeleteEmployeeBtn
        {
            get; set;
        }

        public async void OnViewEmployeeBtn_Click()
        {
            HttpResponseMessage response = await client.GetAsync("/api/employee");
            response.EnsureSuccessStatusCode();
            var employees = await response.Content.ReadAsAsync<IEnumerable<DB_Employee>>();
            EmployeeList=employees.ToList();
        }
        private DB_Employee _selectedEmployee;
        public DB_Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {

                if (value != _selectedEmployee)
                {
                    _selectedEmployee = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedEmployee"));
                    }
                }

            }
        }


        public async void OnAddEmployeeBtn_Click()
        {
            AddEmployee addEmployee = new AddEmployee(client);
            addEmployee.ShowDialog();
            HttpResponseMessage response = await client.GetAsync("/api/employee");
            response.EnsureSuccessStatusCode();
            var employees = await response.Content.ReadAsAsync<IEnumerable<DB_Employee>>();
            EmployeeList = employees.ToList();
        }

        public async void OnUpdateEmployeeBtn_Click()
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("You must select a employee");
            }
            else
            {
                UpdateEmployee updateEmployee = new UpdateEmployee(SelectedEmployee, client);
                updateEmployee.ShowDialog();
                HttpResponseMessage response = await client.GetAsync("/api/employee");
                response.EnsureSuccessStatusCode();
                var employees = await response.Content.ReadAsAsync<IEnumerable<DB_Employee>>();
                EmployeeList = employees.ToList();
            }

        }

        public async void OnDeleteEmployeeBtn_Click()
        {
            try
            {   
                HttpResponseMessage response = await client.DeleteAsync("/api/employee/" + SelectedEmployee.EmployeeId);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Employee Successfully Deleted");
                HttpResponseMessage responses = await client.GetAsync("/api/employee");
                responses.EnsureSuccessStatusCode();
                var employees = await responses.Content.ReadAsAsync<IEnumerable<DB_Employee>>();
                EmployeeList = employees.ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured on deletion");
            }
        }

    }

}
