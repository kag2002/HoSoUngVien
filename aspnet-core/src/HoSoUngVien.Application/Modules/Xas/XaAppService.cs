using Abp.Domain.Repositories;
using HoSoUngVien.DbEntities;
using HoSoUngVien.Modules.Xas.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.Modules.Xas
{
    public class XaAppService:HoSoUngVienAppServiceBase
    {
        private readonly IRepository<Xa> _xa;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public XaAppService(IRepository<Xa> xa)
        {
            _xa = xa;
        }
        public async Task<List<XaFullDto>> GetAllXa()
        {
            try { 
              var xas = await _xa.GetAllListAsync();
              var xaFullDtos = xas.Select(x => new XaFullDto
              {
                Id= x.Id,
                HuyenId= x.HuyenId,
                TenXa = x.TenXa,
                Note = x.Note
              }).ToList();
              return xaFullDtos;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error get all xa:{e}");
                throw;
            }       
        }

        public async Task<List<XaFullDto>> GetXaByHuyenId(int huyenId)
        {
            try
            {
                var xas = await _xa.GetAllListAsync(xa=>xa.HuyenId==huyenId);
                var xaFullDtos = xas.Select(x => new XaFullDto
                {
                    Id = x.Id,
                    HuyenId = x.HuyenId,
                    TenXa = x.TenXa,
                    Note = x.Note
                }).ToList();
                return xaFullDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error get all xa:{e}");
                throw;
            }
        }



        public async Task<bool> AddXa(XaDto xaDtoInput)
        {
            try {
              var xa = new Xa
              {
                  HuyenId = xaDtoInput.HuyenId,
                TenXa = xaDtoInput.TenXa,
                Note = xaDtoInput.Note
              };
              await _xa.InsertAsync(xa);
              return true; 
            }
            catch(Exception e) {
                Console.WriteLine($"Error Add Xa: {e}");
                throw;
            }
        }

        public async Task<bool> UpdateXa(XaFullDto xaFullDto)
        {
            try {   
                if(xaFullDto == null) throw new ArgumentNullException(nameof(xaFullDto),"Xa Input Null");
                var existingXa = await _xa.FirstOrDefaultAsync(xa => xa.Id==xaFullDto.Id);
                if (existingXa == null) throw new ArgumentNullException(nameof(xaFullDto), "Xa Input Null");
                existingXa.HuyenId = xaFullDto.HuyenId;
                existingXa.TenXa= xaFullDto.TenXa;
                existingXa.Note= xaFullDto.Note;
                await _xa.UpdateAsync(existingXa);
                return true; 
            }
            catch(Exception e) { Console.WriteLine($"Error Updating Xa:{e}"); throw; }
        }

        public async Task<bool> DeleteXa(int id)
        {
            try
            {
                var existingXa = await _xa.FirstOrDefaultAsync(xa => xa.Id == id);
                if (existingXa == null) throw new ArgumentNullException($"Khong ton tai xa voi id :{id}");
                await _xa.DeleteAsync(existingXa);
                return true;
            }
            catch(Exception e) {
            Console.WriteLine($"Error Delete :{e}");
                throw;
            }
          
        }
    }
}
