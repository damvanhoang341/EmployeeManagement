using BusinessObject;
using Microsoft.Identity.Client.NativeInterop;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataComboboxRole();
            LoadSearchRole_Down();
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
            try
            {
                AccountMember newAccount = new AccountMember()
                {
                    MemberId = txbID.Text,
                    FullName = txbName.Text,
                    MemberPassword = txbPass.Password,
                    EmailAddress = txbEmail.Text,
                };
                if (cbnRole.SelectedItem.Equals("Admin"))
                {
                    newAccount.MemberRole = 1;
                }
                else if (cbnRole.SelectedItem.Equals("Staff"))
                {
                    newAccount.MemberRole = 2;
                }
                else
                {
                    newAccount.MemberRole = 3;
                }
                _accountService.updateAccount(newAccount);
                LoadPoject();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AccountMember newAccount = new AccountMember()
                {
                    MemberId = txbID.Text,
                    FullName = txbName.Text,
                    MemberPassword = txbPass.Password,
                    EmailAddress = txbEmail.Text,
                };
                if (cbnRole.SelectedItem.Equals("Admin"))
                {
                    newAccount.MemberRole = 1;
                }
                else if (cbnRole.SelectedItem.Equals("Staff"))
                {
                    newAccount.MemberRole = 2;
                }
                else
                {
                    newAccount.MemberRole = 3;
                }
                _accountService.addtAccount(newAccount);
                LoadPoject();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txbID.Clear();
            txbName.Clear();
            txbPass.Clear();
            txbEmail.Clear();
            cbnRole.SelectedIndex = cbnRole.Items.Count - 1;   
        }

        private void btnDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (loadData.SelectedItem is AccountMember account)
                {
                    try
                    {
                        _accountService.removeAccount(account);
                        LoadPoject();
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = $"An error occurred: {ex.Message}";
                        if (ex.InnerException != null)
                        {
                            errorMessage += $"\nInner Exception: {ex.InnerException.Message}";
                        }
                        MessageBox.Show(errorMessage);
                    }
                }
            }
            //if(loadData.SelectedItems is AccountMember account)
            //{
            //    MessageBoxResult result = MessageBox.Show(
            //         "Are you sure you want to delete the selected account?",
            //         "Confirm Delete",
            //         MessageBoxButton.YesNo
            //     );
            //    if (result == MessageBoxResult.Yes)
            //    {
            //        _accountService.removeAccount(account);
            //    }
            //}
        }

        private void loadData_Changed(object sender, SelectionChangedEventArgs e)
        {
            if(loadData.SelectedItem is AccountMember account)
            {
                txbID.Text = account.MemberId;
                txbName.Text = account.FullName;
                txbPass.Password = account.MemberPassword;
                txbEmail.Text = account.EmailAddress;
                if(account.MemberRole == 1)
                {
                    cbnRole.Text = "Admin";
                }else if(account.MemberRole == 2)
                {
                    cbnRole.Text = "Staff";
                }
                else
                {
                    cbnRole.Text = "Employee";
                }
            }
        }

        private void dataRole(object sender, EventArgs e)
        {
            LoadDataComboboxRole();
        }

        public void LoadDataComboboxRole()
        {
            cbnRole.Items.Clear();
            cbnRole.Items.Add("Choose select");
            cbnRole.Items.Add("Admin");
            cbnRole.Items.Add("Staff");
            cbnRole.Items.Add("Employee");
            cbnRole.Items.Add("");
            cbnRole.SelectedIndex = 0;
        }

        private void cbnSearchRole_Down(object sender, EventArgs e)
        {
            LoadSearchRole_Down();
            
        }

        public void LoadSearchRole_Down()
        {
            txbSearchRole.Items.Clear();
            txbSearchRole.Items.Add("Select All");
            txbSearchRole.Items.Add("Admin");
            txbSearchRole.Items.Add("Staff");
            txbSearchRole.Items.Add("Employee");
            txbSearchRole.Items.Add("");
        }

        private void cbnSearchRole_Changed(object sender, SelectionChangedEventArgs e)
        {
            if(txbSearchRole.SelectedItem != null)
            {
                if (txbSearchRole.SelectedItem.Equals("Select All"))
                {
                    loadData.ItemsSource = null;
                    var accounts = _accountService.getAllAcount();
                    inheritanceAccounts = accounts.Select(a => new InheritanceAccount
                    {
                        MemberId = a.MemberId,
                        MemberPassword = a.MemberPassword,
                        FullName = a.FullName,
                        EmailAddress = a.EmailAddress,
                        MemberRole = a.MemberRole
                    }).ToList();
                    loadData.ItemsSource = inheritanceAccounts;
                }
                else if (txbSearchRole.SelectedItem.Equals("Admin"))
                {
                    loadData.ItemsSource = null;
                    var accounts = _accountService.getAccountByRole(1);
                    inheritanceAccounts = accounts.Select(a => new InheritanceAccount
                    {
                        MemberId = a.MemberId,
                        MemberPassword = a.MemberPassword,
                        FullName = a.FullName,
                        EmailAddress = a.EmailAddress,
                        MemberRole = a.MemberRole
                    }).ToList();
                    loadData.ItemsSource = inheritanceAccounts;
                }
                else if (txbSearchRole.SelectedItem.Equals("Staff"))
                {
                    loadData.ItemsSource = null;
                    var accounts = _accountService.getAccountByRole(2);
                    inheritanceAccounts = accounts.Select(a => new InheritanceAccount
                    {
                        MemberId = a.MemberId,
                        MemberPassword = a.MemberPassword,
                        FullName = a.FullName,
                        EmailAddress = a.EmailAddress,
                        MemberRole = a.MemberRole
                    }).ToList();
                    loadData.ItemsSource = inheritanceAccounts;
                }
                else
                {
                    loadData.ItemsSource = null;
                    var accounts = _accountService.getAccountByRole(3);
                    inheritanceAccounts = accounts.Select(a => new InheritanceAccount
                    {
                        MemberId = a.MemberId,
                        MemberPassword = a.MemberPassword,
                        FullName = a.FullName,
                        EmailAddress = a.EmailAddress,
                        MemberRole = a.MemberRole
                    }).ToList();
                    loadData.ItemsSource = inheritanceAccounts;
                }
            }
        }

        private void txbSearchName_Changed(object sender, RoutedEventArgs e)
        {
            var role = txbSearchRole.Text;
            var name = txbSearchName.Text;
            loadData.ItemsSource = null;
            var accounts = _accountService.getAccountByRole(name,role);
            inheritanceAccounts = accounts.Select(a => new InheritanceAccount
            {
                MemberId = a.MemberId,
                MemberPassword = a.MemberPassword,
                FullName = a.FullName,
                EmailAddress = a.EmailAddress,
                MemberRole = a.MemberRole
            }).ToList();
            loadData.ItemsSource = inheritanceAccounts;
        }

        private void btnClearn_Click(object sender, RoutedEventArgs e)
        {
            txbSearchRole.SelectedIndex=txbSearchRole.Items.Count-1;
            txbSearchName.Clear();
            txbSearchID.Clear();

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var id = txbSearchID.Text;
            var account = _accountService.getAccountById(id);
            if (account != null)
            {
                var inheritanceAccounts = new List<InheritanceAccount>
                {
                    new InheritanceAccount
                    {
                        MemberId = account.MemberId,
                        MemberPassword = account.MemberPassword,
                        FullName = account.FullName,
                        EmailAddress = account.EmailAddress,
                        MemberRole = account.MemberRole
                    }
                };
                loadData.ItemsSource = inheritanceAccounts;
            }
        }
    }
}
