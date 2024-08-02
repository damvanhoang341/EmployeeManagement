using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Siderbar_DashboardButtonClicked(object sender, EventArgs e)
        {
            MainFrame.Navigate(new pages.Dashboard());
        }

        private void Siderbar_EmployeeButtonClicked(object sender, EventArgs e)
        {
            MainFrame.Navigate(new pages.EmployeeManager());
        }
        private void Siderbar_AccountButtonClicked(object sender, EventArgs e)
        {
            MainFrame.Navigate(new pages.AccountManager());
        }
        private void Siderbar_CountryButtonClicked(object sender, EventArgs e)
        {
            MainFrame.Navigate(new pages.CountryManager());
        }
        private void Siderbar_DepartmentButtonClicked(object sender, EventArgs e)
        {
            MainFrame.Navigate(new pages.DepartmentManager());
        }
        private void Siderbar_JobButtonClicked(object sender, EventArgs e)
        {
            MainFrame.Navigate(new pages.JobManager());
        }
        private void Siderbar_LocationButtonClicked(object sender, EventArgs e)
        {
            MainFrame.Navigate(new pages.LocationManager());
        }
        private void Siderbar_RegionButtonClicked(object sender, EventArgs e)
        {
            MainFrame.Navigate(new pages.RegionManager());
        }
    }
}