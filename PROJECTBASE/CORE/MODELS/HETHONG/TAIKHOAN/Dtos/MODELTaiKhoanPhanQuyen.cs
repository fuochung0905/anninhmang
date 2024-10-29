namespace MODELS.HETHONG.TAIKHOAN.Dtos
{
    public class MODELTaiKhoanPhanQuyen
    {
        public MODELTaiKhoan TaiKhoan { get; set; }
        public List<MODELPhanQuyen> PhanQuyen { get; set; }
        public List<MODELMenuLogin> Menu { get; set; }
        public List<MODELNhomQuyenLogin> NhomQuyen { get; set; }
    }

    public class MODELMenuLogin
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string TenGoi { get; set; }
        public Guid NhomQuyenId { get; set; }
        public int? Sort { get; set; }
        public bool IsShowMenu { get; set; } = true;
    }

    public class MODELNhomQuyenLogin
    {
        public Guid Id { get; set; }
        public string TenGoi { get; set; }
        public int? Sort { get; set; }
        public string Icon { get; set; }
    }
}
