using Abp.Domain.Repositories;
using HoSoUngVien.DbEntities;
using HoSoUngVien.Modules.Huyens.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.Modules.Huyens
{
    public class HuyenAppService:HoSoUngVienAppServiceBase
    {
        private readonly IRepository<Huyen> _huyen;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HuyenAppService(IRepository<Huyen> huyen)
        {
            _huyen = huyen;
        }

        public async Task<List<HuyenFullDto>> GetAllHuyen()
        {
            try
            {
                var huyens = await _huyen.GetAllListAsync();
                var huyenFullDtos = huyens.Select(huyen => new HuyenFullDto
                {
                    Id = huyen.Id,
                    TinhId = huyen.TinhId,
                    TenHuyen = huyen.TenHuyen,
                    Note = huyen.Note
                    
                }).ToList();
                return huyenFullDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in GetAllHuyen: {e}");
                throw;
            }
        }


        public async Task<bool> AddHuyen(HuyenDto huyenDtoInput)
        {
            try {
                if (huyenDtoInput == null)
                {
                    throw new ArgumentNullException(nameof(huyenDtoInput), "Huyen input is null.");
                    
                }
                var newHuyen = new Huyen
                {
                  TinhId=huyenDtoInput.TinhId,
                  TenHuyen = huyenDtoInput.TenHuyen,
                  Note = huyenDtoInput.Note
                };
                await _huyen.InsertAsync(newHuyen); 
                return true;
            }
            catch(Exception e) {
                Console.WriteLine( $"Error Add Huyen:{e}");
                throw;
            }
            
        }

        public async Task<bool> UpdateHuyen(HuyenFullDto huyenFullDto)
        {

            try
            {
              if (huyenFullDto == null)
                throw new ArgumentNullException(nameof(huyenFullDto),"Huyen input Null");
              
              var existingHuyen = await _huyen.FirstOrDefaultAsync(h => h.Id == huyenFullDto.Id);
              if (existingHuyen == null)
                {
                throw new ArgumentException(nameof(huyenFullDto),$"Huyen voi id {huyenFullDto.Id} khong ton tai");     
                }

              existingHuyen.TinhId = huyenFullDto.TinhId;
              existingHuyen.TenHuyen = huyenFullDto.TenHuyen;
              existingHuyen.Note = huyenFullDto.Note; 
              await _huyen.UpdateAsync(existingHuyen);
              return true;
            }
           
            catch(Exception e)
            {
                Console.WriteLine($"Error Update Huyen:{e}");
                throw;
            }

        }

        public async Task<bool> DeleteHuyen(int id)
        {
          
            try
            {
               var existingHuyen = await _huyen.FirstOrDefaultAsync(h => h.Id == id);
                if (existingHuyen == null) throw new ArgumentNullException($"Khong ton tai huyen voi id:{id}");
                await _huyen.DeleteAsync(existingHuyen);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error Delete Huyen:{e}");
                throw;
                
            } 
        }
    }
}
