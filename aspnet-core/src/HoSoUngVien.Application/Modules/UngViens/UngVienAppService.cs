using Abp.Domain.Repositories;
using HoSoUngVien.DbEntities;
using HoSoUngVien.Modules.UngViens.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HoSoUngVien.Modules.UngViens
{
    public class UngVienAppService : HoSoUngVienAppServiceBase
    {
        private readonly IRepository<UngVien> _ungVien;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UngVienAppService(IRepository<UngVien> ungVien)
        {
            _ungVien = ungVien;
        }
        public async Task<List<UngVienFullDto>> GetAllUngVien(){
            try {
                var ungViens = await _ungVien.GetAllListAsync();
                var ungVienFullDtos = ungViens.Select(uv => new UngVienFullDto
            {
                    Id= uv.Id,
                Ten = uv.Ten,
                GioiTinh = uv.GioiTinh,
                NamSinh = uv.NamSinh,
                CMND = uv.CMND,
                QuocGiaId = uv.QuocGiaId,
                TinhId = uv.TinhId,
                HuyenId = uv.HuyenId,
                XaId = uv.XaId
            }).ToList();
            return ungVienFullDtos; }
            catch(Exception e) {
                Console.WriteLine($"Error get UngVien: ${e}");throw;
            }
        }

        public async Task<List<UngVienFullDto>> GetUngVienByCMND(string cmnd)
        {
            try
            {
                var ungViens = await _ungVien.GetAllListAsync(uv=>uv.CMND==cmnd);
                var ungVienFullDtos = ungViens.Select(uv => new UngVienFullDto
                {
                    Id=uv.Id,
                    Ten = uv.Ten,
                    GioiTinh = uv.GioiTinh,
                    NamSinh = uv.NamSinh,
                    CMND = uv.CMND,
                    QuocGiaId = uv.QuocGiaId,
                    TinhId = uv.TinhId,
                    HuyenId = uv.HuyenId,
                    XaId = uv.XaId
                }).ToList();
                return ungVienFullDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error get UngVien: ${e}"); throw;
            }
        }

        public async Task<bool> AddUngVien(UngVienDto ungVienDto) {
            try
            {
                if (ungVienDto == null) throw new ArgumentNullException(nameof(ungVienDto), $"Ung Vien Input Null");
                var newUngVien = new UngVien
                {
                    Ten = ungVienDto.Ten,
                    GioiTinh = ungVienDto.GioiTinh,
                    NamSinh = ungVienDto.NamSinh,
                    CMND = ungVienDto.CMND,
                    QuocGiaId = ungVienDto.QuocGiaId,
                    TinhId = ungVienDto.TinhId,
                    HuyenId = ungVienDto.HuyenId,
                    XaId = ungVienDto.XaId
                };
                await _ungVien.InsertAsync(newUngVien);
                return true;
                }
            catch(Exception e) { Console.WriteLine($"Error Add Ung Vien: {e}"); throw; }
            }
            
        public async Task<bool> Update(UngVienFullDto ungVienFullDto)
        {
            try
            {
            if(ungVienFullDto == null) { throw new ArgumentNullException(nameof(ungVienFullDto), $"Ung vien input Null"); }
            var existingUngVien = await _ungVien.FirstOrDefaultAsync(uv => uv.Id == ungVienFullDto.Id);
            if(existingUngVien == null) { throw new ArgumentNullException(nameof(ungVienFullDto), $"Ung vien id:{ungVienFullDto.Id} khong ton tai"); }

            existingUngVien.Ten = ungVienFullDto.Ten;
            existingUngVien.GioiTinh = ungVienFullDto.GioiTinh;
            existingUngVien.NamSinh = ungVienFullDto.NamSinh;
            existingUngVien.CMND = ungVienFullDto.CMND;
            existingUngVien.QuocGiaId = ungVienFullDto.QuocGiaId;
            existingUngVien.TinhId = ungVienFullDto.TinhId;
            existingUngVien.HuyenId = ungVienFullDto.HuyenId;
            existingUngVien.XaId = ungVienFullDto.XaId;
            await _ungVien.UpdateAsync(existingUngVien);
            return true;
            }
            catch(Exception e) {
                Console.WriteLine($"Error Update Ung Vien:{e}");
                throw;
          } 
            
        }
        public async Task<bool> Delete(int id)
        {
                try {
                var existingUngVien = await _ungVien.FirstOrDefaultAsync(ungvien => ungvien.Id == id);
                    if (existingUngVien == null) { throw new ArgumentNullException ($"Khong ton tai ung vien co id {id}"); }
                    await _ungVien.DeleteAsync(existingUngVien);
                    return true;
                }
                catch(Exception e) { 
                    Console.WriteLine($"Error delete Ung Vien:{e}");
                    throw;

                }
        }
                  
    }
}
