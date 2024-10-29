using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.HOCSINH.Dtos
{
    public class MODELHocSinh:MODELBase
    {
        public Guid Id { get; set; }

        public string TenHocSinh { get; set; } = null!;

        public string GioiTinh { get; set; } = null!;

        public Guid LopId { get; set; }
    }
}
