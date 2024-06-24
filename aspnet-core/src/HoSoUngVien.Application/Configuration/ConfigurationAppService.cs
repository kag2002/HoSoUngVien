using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using HoSoUngVien.Configuration.Dto;

namespace HoSoUngVien.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : HoSoUngVienAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
