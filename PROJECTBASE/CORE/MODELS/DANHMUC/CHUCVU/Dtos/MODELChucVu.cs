namespace MODELS.DANHMUC.CHUCVU.Dtos
{
    public class MODELChucVu : MODELBase
    {
        public Guid Id { get; set; }
        public string TenGoi { get; set; } = string.Empty;
        public string? Ma { get; set; }
    }
}
