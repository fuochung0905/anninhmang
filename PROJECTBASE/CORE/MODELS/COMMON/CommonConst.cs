namespace MODELS.COMMON
{
    public static class CommonConst
    {
        public static Guid _tinhId = Guid.Parse("836F499B-7CC1-45F8-AADC-87428155297B"); //Đồng Nai
        public static int ExpireTime = 8; // Thời gian hết hạn chức thực là 8 giờ
        public static string _projectName = "TRƯỜNG ĐẠI HỌC BẠC LIÊU";
        public static string _footer = "@" + DateTime.Now.Year + " - Designed by Hiday";
        public static string[] _fileValid = new string[] { ".jpg", ".png", ".jpeg", ".pdf", ".rar", ".zip", ".doc", ".docx", ".xls", ".xlsx" };
        public static string _fileValidString = "Ảnh (jpg, png, jpeg), PDF, Tập tin nén (rar, zip), Văn bản (doc, docx, xls, xlsx)";
        public static string[] _fileHinhAnhValid = new string[] { ".jpg", ".png", ".jpeg" };
        public static string _fileHinhAnhValidString = "Ảnh (jpg, png, jpeg)";
        public static string[] _fileVideoValid = new string[] { ".avi", ".wmv", ".mp4" };
        public static string _fileVideoValidString = "Video (avi, wmv, mp4)";
        public static string[] _fileAudioValid = new string[] { ".mp3", ".mp4", ".wma", ".wav", ".m4a" };
        public static string _fileAudioValidString = "Audio (mp3, mp4, wma, wav, m4a)";
        public static string[] _fileTaiLieuValid = new string[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
        public static string _fileTaiLieuValidString = "PDF, Văn bản (doc, docx, xls, xlsx)";
        public static string[] _fileTaiLieuImportValid = new string[] { ".doc", ".docx", ".xls", ".xlsx" };
        public static string _fileTaiLieuImportValidString = "Văn bản (doc, docx, xls, xlsx)";

        public static Guid _loaiTaiSanLTS03Id = Guid.Parse("534A345D-6957-466A-9BC3-E7610DFF75A3"); //Xe ô tô (LTS03)
        public static Guid _loaiTaiSanLTS04Id = Guid.Parse("B9790B0B-B53D-47AD-A708-DA06C9107D10"); //Phương tiện vận tải khác (ngoài xe ô tô)
        public static Guid _vaiTroNhanVienId = Guid.Parse("688734CB-C0E5-44E1-9951-7A77BE3C43F0"); //Vai trò tài khoản = nhân viên

        public static Guid _loaiChuaPhanBoId = Guid.Parse("FADE7D36-C9F6-4081-BFAA-29404EFF01E1"); //Loại tài sản chưa được phân bổ
        public static Guid _loaiDangSuDungId = Guid.Parse("2C8A5239-E3E3-40D3-8817-8FDD19BABD0D"); //Loại tài sản đang được sử dụng
    }
}
