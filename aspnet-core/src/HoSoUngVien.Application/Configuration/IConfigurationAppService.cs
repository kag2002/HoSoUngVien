using System.Threading.Tasks;
using HoSoUngVien.Configuration.Dto;

namespace HoSoUngVien.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
