using HoSoUngVien.Debugging;

namespace HoSoUngVien
{
    public class HoSoUngVienConsts
    {
        public const string LocalizationSourceName = "HoSoUngVien";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "6f65512326f341f2aac9dfb8146a4a2c";
    }
}
