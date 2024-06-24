﻿using System.Threading.Tasks;
using Abp.Application.Services;
using HoSoUngVien.Authorization.Accounts.Dto;

namespace HoSoUngVien.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
