using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace HoSoUngVien.Localization
{
    public static class HoSoUngVienLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(HoSoUngVienConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HoSoUngVienLocalizationConfigurer).GetAssembly(),
                        "HoSoUngVien.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
