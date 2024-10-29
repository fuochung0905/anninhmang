namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class GetListPhongBanRequest : GetListPagingRequest
    {
        public Guid? DonViId { get; set; }
    }
}
