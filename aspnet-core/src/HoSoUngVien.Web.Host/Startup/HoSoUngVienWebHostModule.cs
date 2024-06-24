using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HoSoUngVien.Configuration;

namespace HoSoUngVien.Web.Host.Startup
{
    [DependsOn(
       typeof(HoSoUngVienWebCoreModule))]
    public class HoSoUngVienWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HoSoUngVienWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HoSoUngVienWebHostModule).GetAssembly());
        }
    }
}
