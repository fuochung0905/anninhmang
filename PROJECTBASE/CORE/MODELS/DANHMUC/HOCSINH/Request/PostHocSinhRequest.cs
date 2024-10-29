using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.HOCSINH.Request
{
    public class PostHocSinhRequest:BaseRequest
    {
        [Required(ErrorMessage ="Mã không được để trống")] 
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Lớp không được để trống")]
        public Guid LopId { get; set; }
        [Required(ErrorMessage = "Tên học sinh không được để trống")]
        public string? TenHocSinh { get; set; } = null!;
        [Required(ErrorMessage = "Giới tính không được để trống")]
        public string? GioiTinh { get; set; } = null!;

 
    }
}
