﻿using StudentDetailsServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFwebApi
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        public UpdateEmployee(DB_Employee selectedEmployee,HttpClient client)
        {
            InitializeComponent();
            this.DataContext = new UpdateEmployeeViewModel(client,selectedEmployee);
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
