using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EmployeeManagementContext context = new EmployeeManagementContext();
        public void addtAccount(AccountMember account)
        {
            context.AccountMembers.Add(account);
            context.SaveChanges();
        }

        public AccountMember getAccountById(string id)
        {
            var account = context.AccountMembers.FirstOrDefault(a => a.MemberId.Equals(id));
            return account;
        }

        public List<AccountMember> getAccountByRole(int role)
        {
            var accounts = context.AccountMembers.Where(a => a.MemberRole.Equals(role)).ToList();
            return accounts;
        }

        public List<AccountMember> getAccountByRole(string name, string role)
        {
            var accounts = context.AccountMembers.Where(a => a.FullName.Contains(name)).ToList();
            if (role.Equals("Admin"))
            {
                var list = accounts.Where(a => a.MemberRole == 1).ToList();
                return list;
            }
            else if (role.Equals("Staff"))
            {
                var list = accounts.Where(a => a.MemberRole == 2).ToList();
                return list;
            }
            else if (role.Equals("Admin"))
            {
                var list = accounts.Where(a => a.MemberRole == 3).ToList();
                return list;
            }
            else
            {
                var list = getAllAcount().Where(a => a.FullName.Contains(name)).ToList();
                return list;
            }
        }


        public List<AccountMember> getAllAcount()
        {
            var listAll = context.AccountMembers.ToList();
            return listAll;
        }

        public void removeAccount(AccountMember account)
        {
            var existingAccount = getAccountById(account.MemberId);
            if (existingAccount != null)
            {
                context.AccountMembers.Remove(existingAccount);
                context.SaveChanges();
            }
            //ko dc xoa thuc the theo doi
            //if (getAccountById(account.MemberId) != null)
            //{
            //    context.AccountMembers.Remove(account);
            //    context.SaveChanges();
            //}
        }

        public void updateAccount(AccountMember account)
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
