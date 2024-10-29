using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class SYS_PHUONGXA
{
    public Guid Id { get; set; }

    public string? MaLienThong { get; set; }

    public string? Ma { get; set; }

    public string? Ten { get; set; }

    public string? MoTa { get; set; }

    public int? ThuTuHienThi { get; set; }

    public Guid? QuanHuyenId { get; set; }

    public bool? IsThanhThi { get; set; }

    public string? NguoiTao { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgaySua { get; set; }

    public string? NguoiXoa { get; set; }

    public DateTime? NgayXoa { get; set; }

    public bool IsDeleted { get; set; }
}
