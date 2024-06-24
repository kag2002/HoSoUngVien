using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using HoSoUngVien.DbEntities;
using HoSoUngVien.Modules.QuocGias.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.Modules.QuocGias
{
    public class QuocGiaAppService:HoSoUngVienAppServiceBase
    {
        private readonly IRepository<QuocGia> _quocGia;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public QuocGiaAppService(IRepository<QuocGia> quocGia)
        {
            _quocGia = quocGia;
        }


        public async Task<List<QuocGiaFullDto>> GetAllQuocGia()
        {
            try
            {
                var quocGias = await _quocGia.GetAllListAsync();
                var quocGiaFullDtos = quocGias.Select(qg => new QuocGiaFullDto
                {
                    Id = qg.Id,
                    TenQuocGia = qg.TenQuocGia,
                    Note = qg.Note
                }).ToList();

                return quocGiaFullDtos;
            }
            catch (Exception e)
            {
               
                Console.WriteLine($"Error in GetAllQuocGia: {e}");
                throw; 
            }
        }

        public async Task<bool> AddQuocGia(QuocGiaDto quocGiaDtoInput)
        {
            try
            {
                
                if (quocGiaDtoInput == null)
                    throw new ArgumentNullException(nameof(quocGiaDtoInput), "QuocGia input is null.");

                var newQuocGia = new QuocGia
                {
                    TenQuocGia = quocGiaDtoInput.TenQuocGia,
                    Note = quocGiaDtoInput.Note
                };

                await _quocGia.InsertAsync(newQuocGia);
                return true;
            }
            catch (Exception e)
            {
             
                Console.WriteLine($"Error in AddQuocGia: {e}");
                throw;
            }
        }
      

        public async Task<bool> UpdateQuocGia(QuocGiaFullDto quocGiaFullDto)
        {
            try
            {
                if (quocGiaFullDto == null)
                    throw new ArgumentNullException(nameof(quocGiaFullDto), "QuocGia input null.");

                var existingQuocGia = await _quocGia.FirstOrDefaultAsync(qg => qg.Id == quocGiaFullDto.Id);
                if (existingQuocGia == null)
                {
                    throw new ArgumentException($"Khong ton tai quoc gia voi id = {quocGiaFullDto.Id}");
                }

                existingQuocGia.TenQuocGia = quocGiaFullDto.TenQuocGia;
                existingQuocGia.Note = quocGiaFullDto.Note;

                await _quocGia.UpdateAsync(existingQuocGia);
                return true;
            }
            catch (Exception e)
            {     
                Console.WriteLine($"Error in UpdateQuocGia: {e}");
                throw; 
            }
        }

        public async Task<bool> DeleteQuocGia(int id)
        {
            try
            {
                var existingQuocGia = await _quocGia.FirstOrDefaultAsync(qg => qg.Id == id);
                if (existingQuocGia == null)
                {
                    throw new ArgumentException($"Khong ton tai quoc gia voi id = {id}");
                }

                await _quocGia.DeleteAsync(existingQuocGia);
                return true;
            }
            catch (Exception e)
            {
              
                Console.WriteLine($"Error in DeleteQuocGia: {e}");
                throw;
            }
        }

    }
}
