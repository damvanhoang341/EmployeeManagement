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

namespace WPFAPP
{
    /// <summary>
    /// Interaction logic for LoginWindown.xaml
    /// </summary>
    public partial class LoginWindown : Window
    {
        private readonly IAccountService _accountService = new AccountService();
        public LoginWindown()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var accountLogin = _accountService.getAccountById(txtUser.Text);
            if (accountLogin.MemberPassword.Equals(txtPass))
            {
                
            }
            else
            {
                MessageBox.Show("invalid value!");
            }
        }
    }
}
