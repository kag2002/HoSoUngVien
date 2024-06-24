using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.DbEntities
{
    public class QuocGia : FullAuditedEntity
    {
        public string TenQuocGia {  get; set; }
        public string Note {  get; set; }

       
    }
}
