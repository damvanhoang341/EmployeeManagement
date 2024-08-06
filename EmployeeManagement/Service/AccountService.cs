using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository = new AccountRepository();

        public void addtAccount(AccountMember account)
        {
            validateAdd(account);
            _accountRepository.addtAccount(account);
        }

        public AccountMember getAccountById(string id)
        {
            return _accountRepository.getAccountById(id);
        }
        public List<AccountMember> getAccountByRole(int role)
        {
            return _accountRepository.getAccountByRole(role);
        }

        public List<AccountMember> getAllAcount()
        {
            var list = _accountRepository.getAllAcount();
            return list;
        }

        public List<AccountMember> getAccountByRole(string name, string role)
        {
            var list = _accountRepository.getAccountByRole(name, role);
            return list;
        }

        public void removeAccount(AccountMember account)
        {
            _accountRepository.removeAccount(account);
        }

        public void updateAccount(AccountMember account)
        {
            validateAdd(account);
            _accountRepository.updateAccount(account);
        }
        
        public void validateAdd(AccountMember account)
        {
            if (getAccountById(account.MemberId)!=null){
                throw new ArgumentException("Account Id is already exists");
            }
            if (string.IsNullOrEmpty(account.FullName))
            {
                throw new ArgumentException("Please enter your name");
            }
            if (string.IsNullOrEmpty(account.EmailAddress))
            {
                throw new ArgumentException("Please enter your name");
            }
            if (!IsValidEmail(account.EmailAddress))
            {
                throw new ArgumentException("Email is not valid");
            }if(string.IsNullOrEmpty(account.MemberPassword))
            {
                throw new ArgumentException("please enter your pass word");
            }if(!checkPass(account))
            {
                throw new ArgumentException("Pass word is not value");
            }
        }

        public Boolean checkPass(AccountMember account)
        {
            if(account.MemberPassword.Count() > 16 && account.MemberPassword.Count() < 8)
            {
                return false;
            }
            bool hasLower = account.MemberPassword.Any(char.IsLower);
            bool hasUpper = account.MemberPassword.Any(char.IsUpper);
            bool hasDigit = account.MemberPassword.Any(char.IsDigit);
            bool hasSpecial = account.MemberPassword.Any(ch => "!@#$%^&*".Contains(ch));

            return hasLower && hasUpper && hasDigit && hasSpecial;
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
                return emailRegex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
