using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HoSoUngVien.EntityFrameworkCore;
using HoSoUngVien.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HoSoUngVien.Web.Tests
{
    [DependsOn(
        typeof(HoSoUngVienWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class HoSoUngVienWebTestModule : AbpModule
    {
        public HoSoUngVienWebTestModule(HoSoUngVienEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HoSoUngVienWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(HoSoUngVienWebMvcModule).Assembly);
        }
    }
}