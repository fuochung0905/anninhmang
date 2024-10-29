namespace MODELS.DANHMUC.Dtos
{
    public class MODELDonVi : MODELBase
    {
        public Guid Id { get; set; }
        public string TenGoi { get; set; }
        public string NguoiLienHe { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string DiaChi { get; set; }
    }
}
