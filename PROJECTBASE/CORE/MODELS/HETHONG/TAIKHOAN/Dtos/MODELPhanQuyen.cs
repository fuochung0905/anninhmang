using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.TAIKHOAN.Dtos
{
    public class MODELPhanQuyen
    {
        public string ControllerName { get; set; } = null!;
        public bool IsXem { get; set; } = false;
        public bool IsThem { get; set; } = false;
        public bool IsCapNhat { get; set; } = false;
        public bool IsXoa { get; set; } = false;
        public bool IsDuyet { get; set; } = false;
        public bool IsThongKe { get; set; } = false;
    }
}
