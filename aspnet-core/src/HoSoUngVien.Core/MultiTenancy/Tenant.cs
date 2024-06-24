using Abp.MultiTenancy;
using HoSoUngVien.Authorization.Users;

namespace HoSoUngVien.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
