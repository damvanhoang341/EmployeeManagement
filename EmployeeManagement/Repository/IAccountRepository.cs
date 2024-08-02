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
        public void addtAccount(AccountMember account);
        public void removeAccount(AccountMember account);
        public void updateAcoounr(AccountMember account);
    }
}
