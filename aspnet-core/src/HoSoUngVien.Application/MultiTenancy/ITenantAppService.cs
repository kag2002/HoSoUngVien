using Abp.Application.Services;
using HoSoUngVien.MultiTenancy.Dto;

namespace HoSoUngVien.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

