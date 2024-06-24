using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HoSoUngVien.DbEntities
{
    public class UngVien : FullAuditedEntity
    {        
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh {  get; set; }
        public string CMND {  get; set; }
        public int QuocGiaId {  get; set; }
        public int TinhId {  get; set; }
        public int HuyenId {  get; set; }
        public int XaId {  get; set; }
    }
}
