using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.LOPP.Dtos
{
    public class MODELLop : MODELBase
    {
        public Guid Id { get; set; }

        public Guid PhongBanId { get; set; }

        public string Lop { get; set; } = null!;
    }
}
