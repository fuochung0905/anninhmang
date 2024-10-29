namespace MODELS.DANHMUC.PHONGBAN.Dtos
{
   public class MODELPhongBan : MODELBase
   {
        public Guid Id { get; set; }
        public string TenGoi { get; set; } = string.Empty;
        public Guid DonViId { get; set; }
        public string? Ma { get; set; }
        public string? TenDonVi { get; set; }
        public string? MoTa { get; set; }
        public string? GhiChu { get; set; }
    }
}
