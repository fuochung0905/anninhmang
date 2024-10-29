namespace MODELS.HETHONG.TAIKHOAN.Dtos
{
    public class MODELNhatKy
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; } = null!;
        public string Level { get; set; } = null!;
        public string Logger { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Exception { get; set; }
        public string UserName { get; set; }
        public Guid DonViId { get; set; }
        public string DonVi { get; set; }
        public string IpAddress { get; set; }
        public string Loai { get; set; }
    }
}
