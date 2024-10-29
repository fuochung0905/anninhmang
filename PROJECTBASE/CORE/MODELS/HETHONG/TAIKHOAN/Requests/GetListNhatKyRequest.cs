namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class GetListNhatKyRequest : GetListPagingRequest
    {
        public string Level { get; set; }
        public string? DonViId { get; set; }
        public int LoaiId { get; set; }
        public string LoaiHoatDong { get; set; }
        public string? UserName { get; set; }
    }
}
