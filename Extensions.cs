using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineThreeNineInfection
{
 
    public static class Extensions
    {
        public static bool IsAnySCP(this RoleType role)
        {
            return role == RoleType.Scp049 || role == RoleType.Scp0492 || role == RoleType.Scp079 || role == RoleType.Scp096 || role == RoleType.Scp106 || role == RoleType.Scp173 || role == RoleType.Scp93953 || role == RoleType.Scp93989;
        }
    }
}
