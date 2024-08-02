using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository = new AccountRepository();

        public void addtAccount(AccountMember account)
        {
            throw new NotImplementedException();
        }

        public AccountMember getAccountById(string id)
        {
            return _accountRepository.getAccountById(id);
        }

        public List<AccountMember> getAllAcount()
        {
            var list = _accountRepository.getAllAcount();
            return list;
        }

        public void removeAccount(AccountMember account)
        {
            throw new NotImplementedException();
        }

        public void updateAcoounr(AccountMember account)
        {
            throw new NotImplementedException();
        }
    }
}
