namespace MODELS.DANHMUC.TINHTHANH.Response
{
    public class MODELTinhThanh : MODELBase
    {
        public Guid Id { get; set; }
        public string? MaLienThong { get; set; }
        public string? Ma { get; set; } = string.Empty;
        public string? Ten { get; set; } = string.Empty;
        public int? ThuTuHienThi { get; set; }
    }
}
