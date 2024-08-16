using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Service;
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
using static System.Net.Mime.MediaTypeNames;

namespace AppWPF.pages
{
    /// <summary>
    /// Interaction logic for DepartmentManager.xaml
    /// </summary>
    public partial class DepartmentManager : UserControl
    {
        private readonly IDepartmentService _departmentService = new DepartmentService();
        private readonly ILocationService _locationService = new LocationService();
        public DepartmentManager()
        {
            InitializeComponent();
            LoadProject();
            }

        public void LoadProject()
        {
            loadData.ItemsSource = null;
            
            loadData.ItemsSource = _departmentService.getAllDepartment();
        }


        private void txbSearchCity_Opened(object sender, EventArgs e)
        {
            loadDataCbnCity();
        }

        public void loadDataCbnCity()
        {
            cbnSearchCity.Items.Clear();
            cbnSearchCity.Items.Add("Select All");
            var list = _locationService.GetLocations();
            foreach (var city in list)
            {
                cbnSearchCity.Items.Add(city.City);
            }
            cbnSearchCity.Items.Add("");
        }

        private void cbnSearchCity_Changed(object sender, SelectionChangedEventArgs e)
        {
            loadDataCityChanged();
        }

        public void loadDataCityChanged()
        {
            if(cbnSearchCity.SelectedItem != null)
            {
                if (cbnSearchCity.SelectedIndex == 0 || cbnSearchCity.SelectedIndex == (cbnSearchCity.Items.Count - 1))
                {
                    var list = _departmentService.getAllDepartment();
                    loadData.ItemsSource = list;
                }
                else
                {
                    var city = cbnSearchCity.SelectedItem.ToString();
                    var cityName = _locationService.SearchId(city);
                    var list = _departmentService.getDepartmentsByLocationId(cityName);
                    loadData.ItemsSource = list;
                }
            }
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txbSearchID.Text))
                {
                    var id = int.Parse(txbSearchID.Text);
                    var department = _departmentService.searchById(id);
                    loadData.ItemsSource = null;
                    loadData.ItemsSource = department.Include(d => d.Location)
                                                          .Include(d => d.Manager)
                                                          .ToList();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearn_Click(object sender, RoutedEventArgs e)
        {
            cbnSearchCity.SelectedIndex = cbnSearchCity.Items.Count-1;
            txbSearchID.Text = null;
            txbSearchName.Clear();
        }

        private void txbSearchName_Changed(object sender, RoutedEventArgs e)
        {
            var name = txbSearchName.Text;
            var city = _locationService.SearchId(cbnSearchCity.SelectedItem.ToString());
            loadData.ItemsSource = _departmentService.searhDepartmentByName(name,city);
        }

        private void loadData_Changed(object sender, SelectionChangedEventArgs e)
        {
            if(loadData.SelectedItem is Department)
            {
                
            }
        }
    }
}
