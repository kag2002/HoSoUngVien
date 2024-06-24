using System.Threading.Tasks;
using Abp.Application.Services;
using HoSoUngVien.Sessions.Dto;

namespace HoSoUngVien.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
