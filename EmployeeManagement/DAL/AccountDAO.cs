using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAO
    {
        private readonly EmployeeManagementContext context = new EmployeeManagementContext();
        public List<AccountMember> getAllAcount()
        {
            var listAll = context.AccountMembers.ToList();
            return listAll;
        }
        public AccountMember getAccountById(string id)
        {
            var account = context.AccountMembers.FirstOrDefault(a => a.MemberId.Equals(id));
            return account;
        }
        public void addtAccount(AccountMember account)
        {
            context.AccountMembers.Add(account);
            context.SaveChanges();
        }
        public void removeAccount(AccountMember account)
        {
            if(getAccountById(account.MemberId) != null)
            {
                context.AccountMembers.Remove(account);
                context.SaveChanges();
            }
        }
        public void updateAcoounr(AccountMember account)
        {
            if (getAccountById(account.MemberId) != null)
            {
                context.AccountMembers.Attach(account);
                context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
