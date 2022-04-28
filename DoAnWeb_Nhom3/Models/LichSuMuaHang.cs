using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWeb_Nhom3.Models
{
    public class LichSuMuaHang
    {
        public string TenKH { set; get; }
        public string TenSP { set; get; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayDat { set; get; }
        public int SoLuong { set; get; }
        public decimal? DonGia { set; get; }
    }
}