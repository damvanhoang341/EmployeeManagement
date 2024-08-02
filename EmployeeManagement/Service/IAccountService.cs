using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAccountService
    {
        public List<AccountMember> getAllAcount();
        public AccountMember getAccountById(string id);
        public void addtAccount(AccountMember account);
        public void removeAccount(AccountMember account);
        public void updateAcoounr(AccountMember account);
    }
}
