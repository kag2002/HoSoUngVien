using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.Modules.Tinhs.Dto
{
    public class TinhFullDto
    {
        public int Id { get; set; }
        public int QuocGiaId {  get; set; }
        public string TenTinh { get; set; }
        public string Note { get; set; }
    }
}
