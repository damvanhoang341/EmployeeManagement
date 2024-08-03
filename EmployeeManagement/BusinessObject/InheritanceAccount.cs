using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class InheritanceAccount : AccountMember
    {
        public bool IsDeleted { get; private set; }
        public string MemberRoleString
        {
            get
            {
                return MemberRole switch
                {
                    1 => "Admin",
                    2 => "Staff",
                    3 => "Employee",
                    _ => "Unknown",
                };
            }
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
