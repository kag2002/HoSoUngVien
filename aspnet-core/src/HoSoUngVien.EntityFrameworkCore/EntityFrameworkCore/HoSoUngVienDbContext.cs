using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HoSoUngVien.Authorization.Roles;
using HoSoUngVien.Authorization.Users;
using HoSoUngVien.MultiTenancy;
using HoSoUngVien.DbEntities;

namespace HoSoUngVien.EntityFrameworkCore
{
    public class HoSoUngVienDbContext : AbpZeroDbContext<Tenant, Role, User, HoSoUngVienDbContext>
    {
        public DbSet<QuocGia> BwQuocGia { get; set; }
        public DbSet<Tinh> BwTinh { get; set; }
        public DbSet<Huyen> BwHuyen { get; set; }
        public DbSet<Xa> BwXa { get; set; }
        public DbSet<UngVien> BwUngVien { get; set; }

        public HoSoUngVienDbContext(DbContextOptions<HoSoUngVienDbContext> options)
            : base(options)
        {
        }
    }
}
