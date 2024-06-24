using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HoSoUngVien.EntityFrameworkCore
{
    public static class HoSoUngVienDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HoSoUngVienDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HoSoUngVienDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
