using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.DbEntities
{
    public class Tinh : FullAuditedEntity
    {
        public int QuocGiaId {get;set;}
        public string TenTinh { get; set; }
        public string Note { get; set; }


        public ICollection<Huyen> Huyens { get; set; }


    }
}
