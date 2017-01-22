using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFwebApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
    
      HttpClient client = new HttpClient();
      public MainWindow()
        {
            InitializeComponent();
    //        List<string> genderList = new List<string>();
    //        genderList.Add("Male");
    //        genderList.Add("Female");
    //        cbxGender.ItemsSource = genderList;

    //        client.BaseAddress = new Uri("http://localhost:8088");
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //        this.Loaded += MainWindow_Loaded;
        }

    //    async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    //    {
    //        HttpResponseMessage response = await client.GetAsync("/api/employee");
    //        response.EnsureSuccessStatusCode(); // Throw on error code.
    //        var students = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
    //        employeesListView.ItemsSource = students;
    //    }

       private  void btnGetEmployee_Click(object sender, RoutedEventArgs e)
      {
    //        try
    //        {
    //            HttpResponseMessage response = await client.GetAsync("/api/employee/" + txtID.Text);
    //            response.EnsureSuccessStatusCode(); // Throw on error code.
    //            var employees = await response.Content.ReadAsAsync<Employee>();
    //            employeeDetailsPanel.Visibility = Visibility.Visible;
    //            employeeDetailsPanel.DataContext = employees;
    //        }
    //        catch(Exception)
    //        {
    //            MessageBox.Show("Employee not Found");
    //        }
      }

      private  void btnNewEmployee_Click(object sender, RoutedEventArgs e)
       {
    //        try
    //        {
    //            var employee = new Employee()
    //            {
    //                name = txtEmployeeName.Text,
    //                id = int.Parse(txtEmployeeID.Text),
    //                gender = cbxGender.SelectedItem.ToString(),
    //                age = int.Parse(txtAge.Text)
    //            };
    //            var response = await client.PostAsJsonAsync("/api/employee/", employee);
    //            response.EnsureSuccessStatusCode(); // Throw on error code.
    //            MessageBox.Show("Employee Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
    //            employeesListView.ItemsSource = await GetAllEmployees();
    //            employeesListView.ScrollIntoView(employeesListView.ItemContainerGenerator.Items[employeesListView.Items.Count - 1]);
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("Employee not Added, May be due to Duplicate ID" +ex);
    //        }
      }

       private  void btnUpdate_Click(object sender, RoutedEventArgs e)
     {
    //        try
    //        {
    //            var employee = new Employee()
    //            {
    //                name = txtEmployeeName.Text,
    //                id = int.Parse(txtEmployeeID.Text),
    //                gender = cbxGender.SelectedItem.ToString(),
    //                age = int.Parse(txtAge.Text)
    //            };
    //            var response = await client.PutAsJsonAsync("/api/employee/", employee);
    //            response.EnsureSuccessStatusCode(); // Throw on error code.
    //            MessageBox.Show("Employee Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
    //            employeesListView.ItemsSource = await GetAllEmployees();
    //            employeesListView.ScrollIntoView(employeesListView.ItemContainerGenerator.Items[employeesListView.Items.Count - 1]);
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message);
    //        }
      }

        private  void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
    //        try
    //        {
    //            HttpResponseMessage response = await client.DeleteAsync("/api/employee/" + txtID.Text);
    //            response.EnsureSuccessStatusCode(); // Throw on error code.
    //            MessageBox.Show("Employee Successfully Deleted");
    //            employeesListView.ItemsSource = await GetAllEmployees();
    //            employeesListView.ScrollIntoView(employeesListView.ItemContainerGenerator.Items[employeesListView.Items.Count - 1]);
    //        }
    //        catch (Exception)
    //        {
    //            MessageBox.Show("Employee Deletion Unsuccessful");
    //        }
       }

   // public  Task<IEnumerable<Employee>> GetAllEmployees()
    //    {
    //        HttpResponseMessage response = await client.GetAsync("/api/employee");
    //        response.EnsureSuccessStatusCode(); // Throw on error code.
    //        var employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
    //        return employees;
    

    //public class Employee
    //{
    //    public string name { get; set; }
    //    public int id { get; set; }
    //    public string gender { get; set; }
    //    public int age { get; set; }
    //}
}
}
