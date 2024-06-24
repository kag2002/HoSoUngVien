using Abp.Authorization;
using HoSoUngVien.Authorization.Roles;
using HoSoUngVien.Authorization.Users;

namespace HoSoUngVien.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
