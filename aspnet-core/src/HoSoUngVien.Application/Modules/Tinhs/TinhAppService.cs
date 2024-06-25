using Abp.Domain.Repositories;
using HoSoUngVien.DbEntities;
using HoSoUngVien.Modules.Tinhs.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.Modules.Tinhs
{
    public class TinhAppService:HoSoUngVienAppServiceBase
    {
        private readonly IRepository<Tinh> _tinh;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TinhAppService(IRepository<Tinh> tinh)
        {
            _tinh = tinh;
        }

        public async Task<List<TinhFullDto>> GetAllTinh()
        {
            try {
                var tinhs = await _tinh.GetAllListAsync();
                var tinhFullDtos = tinhs.Select(tinh => new TinhFullDto
                {
                    Id = tinh.Id,
                    QuocGiaId=tinh.QuocGiaId,
                    TenTinh = tinh.TenTinh,
                    Note = tinh.Note
                }).ToList();
                return tinhFullDtos;
            }
            catch (Exception e)
            { 
                Console.WriteLine($"Error Get All Tinh: {e}");
                throw;
            }
        }

        public async Task<bool> AddTinh(TinhDto tinhDtoInput)
        {
            if(tinhDtoInput == null) throw new ArgumentNullException(nameof(tinhDtoInput),"Tinh Input Null");
            try {
                var newTinh = new Tinh
                {
                    QuocGiaId = tinhDtoInput.QuocGiaId,
                    TenTinh = tinhDtoInput.TenTinh,
                    Note = tinhDtoInput.Note
                };
                await _tinh.InsertAsync(newTinh);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error add Tinh:{e}");
                throw;
            }
        }
        public async Task<bool> UpdateTinh(TinhFullDto tinhFullDtoInput)
        {
            try
            {
              if (tinhFullDtoInput == null) { throw new ArgumentNullException(nameof(tinhFullDtoInput), "Tinh Input Null"); };
              var existingTinh = await _tinh.FirstOrDefaultAsync(tinh => tinh.Id == tinhFullDtoInput.Id);

              if (existingTinh == null) { throw new ArgumentNullException(nameof(tinhFullDtoInput), $"Tinh voi id {tinhFullDtoInput.Id} khong ton tai"); }

                existingTinh.QuocGiaId = tinhFullDtoInput.QuocGiaId;
              existingTinh.TenTinh = tinhFullDtoInput.TenTinh;
              existingTinh.Note = tinhFullDtoInput.Note;
              await _tinh.UpdateAsync(existingTinh);
              return true;
            }
            catch(Exception e )
            {
                Console.WriteLine( $"Error Update Tinh:{e}");
                throw;
            }
          
        }

        public async Task<bool> Delete(int id)
        {
            try {
            var existingTinh = await _tinh.FirstOrDefaultAsync(tinh=> tinh.Id == id);
            if(existingTinh == null) { throw new ArgumentNullException(nameof(existingTinh), $"Khong ton tai tinh voi id:{id}"); }
            await _tinh.DeleteAsync(existingTinh);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error delete Tinh :{e}");
                throw;
            }
        }

    }
}
