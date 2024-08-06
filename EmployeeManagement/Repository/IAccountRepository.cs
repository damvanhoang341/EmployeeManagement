using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository
    {
        public List<AccountMember> getAllAcount();
        public AccountMember getAccountById(string id);
        public List<AccountMember> getAccountByRole(int role);
        public void addtAccount(AccountMember account);
        public void removeAccount(AccountMember account);
        public void updateAccount(AccountMember account);
        public List<AccountMember> getAccountByRole(string name, string role);
    }
}
