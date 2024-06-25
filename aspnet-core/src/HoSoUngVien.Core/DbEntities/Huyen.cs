using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.DbEntities
{
    public class Huyen : FullAuditedEntity
    {
        public int TinhId { get; set; }
        public string TenHuyen { get; set; }
        public string Note { get; set; }     
        public ICollection<Xa> Xas { get; set; }


    }
}
