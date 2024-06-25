using Abp.Domain.Entities.Auditing;
using HoSoUngVien.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.Modules.Huyens.Dto
{
    public class HuyenDto
    {
        public int TinhId { get; set; }
        public string TenHuyen { get; set; }
        public string Note { get; set; }

        

    }
}
