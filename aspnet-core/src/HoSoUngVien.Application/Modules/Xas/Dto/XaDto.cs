﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoSoUngVien.Modules.Xas.Dto
{
    public class XaDto
    { 
        public int HuyenId {  get; set; }
        public string TenXa { get; set; }
        public string Note { get; set; }
      
    }
}
