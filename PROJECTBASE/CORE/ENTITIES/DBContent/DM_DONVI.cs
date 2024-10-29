using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DM_DONVI
{
    public Guid Id { get; set; }

    public string TenGoi { get; set; } = null!;

    public string? NguoiLienHe { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? DiaChi { get; set; }

    public DateTime NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
}
