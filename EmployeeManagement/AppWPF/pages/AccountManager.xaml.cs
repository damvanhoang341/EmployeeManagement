using BusinessObject;
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

namespace AppWPF.pages
{
    /// <summary>
    /// Interaction logic for AccountManager.xaml
    /// </summary>
    public partial class AccountManager : UserControl
    {
        private IAccountService _accountService = new AccountService();
        private List<InheritanceAccount> inheritanceAccounts;
        public AccountManager()
        {
            InitializeComponent();
            LoadPoject();
        }

        public void LoadPoject()
        {
            loadData.ItemsSource = null;
            var accounts = _accountService.getAllAcount();
            inheritanceAccounts = accounts.Select(a=> new InheritanceAccount{
                MemberId = a.MemberId,
                MemberPassword = a.MemberPassword,
                FullName = a.FullName,
                EmailAddress = a.EmailAddress,
                MemberRole = a.MemberRole
            }).ToList();
            loadData.ItemsSource = inheritanceAccounts;
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
