using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace HoSoUngVien.Controllers
{
    public abstract class HoSoUngVienControllerBase: AbpController
    {
        protected HoSoUngVienControllerBase()
        {
            LocalizationSourceName = HoSoUngVienConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
