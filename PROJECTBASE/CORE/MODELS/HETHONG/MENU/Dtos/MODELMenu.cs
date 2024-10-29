namespace MODELS.HETHONG.TAIKHOAN.Dtos
{
    public class MODELMenu : MODELBase
    {
        public string ControllerName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string TenGoi { get; set; }
        public Guid NhomQuyenId { get; set; }
        public string TenNhom { get; set; }
        public int NhomSort { get; set; }
        public bool CoXem { get; set; } = false;
        public bool CoThem { get; set; } = false;
        public bool CoCapNhat { get; set; } = false;
        public bool CoXoa { get; set; } = false;
        public bool CoDuyet { get; set; } = false;
        public bool CoThongKe { get; set; } = false;
        public bool IsShowMenu { get; set; } = true;
    }
}
