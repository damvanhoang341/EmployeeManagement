using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AppWPF.components
{
    /// <summary>
    /// Interaction logic for Sidebar.xaml
    /// </summary>
    public partial class Sidebar : UserControl
    {
        public event EventHandler EmployeeButtonClicked;
        public event EventHandler DashboardButtonClicked;
        public event EventHandler AccountButtonClicked;
        public event EventHandler CountryButtonClicked;
        public event EventHandler DepartmentButtonClicked;
        public event EventHandler JobButtonClicked;
        public event EventHandler LocationButtonClicked;
        public event EventHandler RegionButtonClicked;
        public Sidebar()
        {
            InitializeComponent();
            string userName = "Admin";
            tblName.Text = userName;
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý khi nhấn button Account
            AccountButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý khi nhấn button Department
            DepartmentButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void CountryButton_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý khi nhấn button Country
            CountryButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void JobButton_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý khi nhấn button Job
            JobButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void LocationButton_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý khi nhấn button Location
            LocationButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void RegionButton_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý khi nhấn button Region
            RegionButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý khi nhấn button Logout
            LocationButtonClicked?.Invoke(this, EventArgs.Empty);

        }
    }
}
