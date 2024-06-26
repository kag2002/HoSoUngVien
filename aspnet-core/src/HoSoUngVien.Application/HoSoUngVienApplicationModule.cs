﻿using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HoSoUngVien.Authorization;

namespace HoSoUngVien
{
    [DependsOn(
        typeof(HoSoUngVienCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class HoSoUngVienApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<HoSoUngVienAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(HoSoUngVienApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
