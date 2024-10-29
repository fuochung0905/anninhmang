namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class GetListPagingTaiKhoanRequest : GetListPagingRequest
    {
        public Guid? PhongBanId { get; set; }
    }
}
