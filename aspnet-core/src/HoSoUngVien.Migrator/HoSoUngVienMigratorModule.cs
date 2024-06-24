using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HoSoUngVien.Configuration;
using HoSoUngVien.EntityFrameworkCore;
using HoSoUngVien.Migrator.DependencyInjection;

namespace HoSoUngVien.Migrator
{
    [DependsOn(typeof(HoSoUngVienEntityFrameworkModule))]
    public class HoSoUngVienMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public HoSoUngVienMigratorModule(HoSoUngVienEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(HoSoUngVienMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                HoSoUngVienConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HoSoUngVienMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
