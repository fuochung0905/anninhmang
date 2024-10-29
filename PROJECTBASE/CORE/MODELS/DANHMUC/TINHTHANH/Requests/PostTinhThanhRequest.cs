namespace MODELS.DANHMUC.TINHTHANH.Requests
{
    public class PostTinhThanhRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public string? MaLienThong { get; set; }
        public string? Ma { get; set; } = string.Empty;
        public string? Ten { get; set; } = string.Empty;
        public int? ThuTuHienThi { get; set; }
    }
}
