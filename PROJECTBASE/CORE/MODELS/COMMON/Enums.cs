namespace MODELS.COMMON
{
    public enum StatusCode
    {
        Success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        InternalError = 500,
        NotImplemented = 501,
        UnknownError = 520
    }
    public enum ExportFileType
    {
        Excel = 1,
        Word = 2,
        HuongDan = 3
    }
    public enum LoaiTrinhDoChuyenMon
    {
        Mau1 = 1,
        Mau2 = 2,
        Mau3 = 3
    }
    public enum ChungLoaiTaiSan
    {
        TaiSanCoDinhHuuHinh = 1,
        TaiSanCoDinhVoHinh = 2,
        TaiSanCoDinhDacThu = 3,
        PhuongTienDiLai = 4
    }
    public enum LoaiXe
    {
        XePhucVuChucDanh = 1,
        XePhucVuChung = 2,
        XeChuyenDung = 3
    }

    /// <summary>
    /// SYS_LOAIHOPDONGLAODONG
    /// </summary>
    public enum LoaiHopDongLaoDong
    {
        HopDongKhongXacDinhThoiHan = 1,
        HopDongXacDinhThoiHan = 2,
        HopDongThuViec = 3
    }

    /// <summary>
    /// SYS_HINHTHUCTRALUONG
    /// </summary>
    public enum HinhThucTraLuong
    {
        ChuyenKhoan = 1,
        TienMat = 2
    }

    /// <summary>
    /// SYS_TRANGTHAINHANSU
    /// </summary>
    public enum TrangThaiNhanSu
    {
        ChoTaoHopDong = 1,
        DaTaoHopDong = 2,
        DangThuViec = 3,
        NghiViec = 4,
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETHOPDONG
    /// </summary>
    public enum TrangThaiDuyetHopDong
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETDONPHEP
    /// </summary>
    public enum TrangThaiDuyetDonPhep
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }
    public enum TrangThaiDuyetKeHoachDanhGiaNhanSu
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    /// <summary>
    /// SYS_KETQUATUYENDUNG
    /// </summary>
    public enum KetQuaTuyenDung
    {
        ChuaCoKetQua = 1,
        Dau = 2,
        Rot = 3
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETDONXINTHOIVIEC
    /// </summary>
    public enum TrangThaiDuyetDonXinThoiViec
    {
        ChoGiaiQuyet = 1,
        PhongVan = 2,
        DaDuyet = 3,
        KhongDuyet = 4
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETTHOATHUANTHOIVIEC
    /// </summary>
    public enum TrangThaiDuyetThoaThuanThoiViec
    {
        DaDuyet = 1,
        ChuaDuyet = 2
    }

    /// <summary>
    /// SYS_KETQUATHUVIEC
    /// </summary>
    public enum KetQuaThuViec
    {
        Dat = 1,
        KhongDat = 2
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETDONLAMTHEMGIO
    /// </summary>
    public enum TrangThaiDuyetDonLamThemGio
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    /// <summary>
    /// KHAOTHI_LOAICAUHOI
    /// </summary>
    public enum LoaiCauHoi
    {
        TracNghiem = 1,
        TuLuan = 2,
        DienKhuyet = 3,
        GhepDoi = 4,
    }

    /// <summary>
    /// SYS_DOKHO
    /// </summary>
    public enum DoKho
    {
        De = 1,
        TrungBinh = 2,
        Kho = 3
    }

    /// <summary>
    /// KHAOTHI_LOAIDETHI
    /// </summary>
    public enum LoaiDeThi
    {
        OnTap = 1,
        Thi = 2,
        KiemTra = 3
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETBAOCAO
    /// </summary>
    public enum TrangThaiDuyetBaoCao
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETCAUHOI
    /// </summary>
    public enum TrangThaiDuyetCauHoi
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETDETHI
    /// </summary>
    public enum TrangThaiDuyetDeThi
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETHOCLIEU
    /// </summary>
    public enum TrangThaiDuyetHocLieu
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETTAILIEUTHAMKHAO
    /// </summary>
    public enum TrangThaiDuyetTaiLieuThamKhao
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    /// <summary>
    /// SYS_MUCDICHSUDUNG
    /// </summary>
    public enum MucDichSuDung
    {
        TaiSanChoDaoTao = 1,
        TaiSanChoKinhDoanh = 2
    }

    /// <summary>
    /// SYS_MUCDICHSUDUNGCAUHOI
    /// </summary>
    public enum MucDichSuDungCauHoi
    {
        OnTap = 1,
        Thi = 2,
        KiemTra = 3
    }

    /// <summary>
    /// SYS_TRANGTHAIDUYETKYTHI
    /// </summary>
    public enum TrangThaiDuyetKyThi
    {
        ChoDuyet = 1,
        DaDuyet = 2,
        KhongDuyet = 3
    }

    public enum HinhThucKyThi
    {
        TrucTuyen = 1,
        TrucTiep = 2
    }

    public enum LoaiKyThi
    {
        ThiThat = 1,
        ThiThu = 2
    }

    /// <summary>
    /// SYS_LOAIHOCLIEU
    /// </summary>
    public enum LoaiHocLieu
    {
        HocLieu = 1,
        BaiGiang = 2
    }
}
