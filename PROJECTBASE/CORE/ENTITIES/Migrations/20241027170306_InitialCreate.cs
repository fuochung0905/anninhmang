using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DM_CHUCVU",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_CHUCVU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_DONVI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_DONVI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_PHONGBAN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonViId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false, defaultValueSql: "(((((0)-(0))-(0))-(0))-(0.0))"),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONGBAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Thread = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Logger = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DonViId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PHANQUYEN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    VaiTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControllerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsXem = table.Column<bool>(type: "bit", nullable: false),
                    IsThem = table.Column<bool>(type: "bit", nullable: false),
                    IsCapNhat = table.Column<bool>(type: "bit", nullable: false),
                    IsXoa = table.Column<bool>(type: "bit", nullable: false),
                    IsDuyet = table.Column<bool>(type: "bit", nullable: false),
                    IsThongKe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYEN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHANQUYEN_NHOMQUYEN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYEN_NHOMQUYEN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_CONFIG",
                columns: table => new
                {
                    SoNgayCanhBaoHopDongSapHetHan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SYS_MENU",
                columns: table => new
                {
                    ControllerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Controller = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NhomQuyenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    CoXem = table.Column<bool>(type: "bit", nullable: false),
                    CoThem = table.Column<bool>(type: "bit", nullable: false),
                    CoCapNhat = table.Column<bool>(type: "bit", nullable: false),
                    CoXoa = table.Column<bool>(type: "bit", nullable: false),
                    CoDuyet = table.Column<bool>(type: "bit", nullable: false),
                    CoThongKe = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsShowMenu = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYEN_QUYEN", x => x.ControllerName);
                });

            migrationBuilder.CreateTable(
                name: "SYS_PHUONGXA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaLienThong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ThuTuHienThi = table.Column<int>(type: "int", nullable: true),
                    QuanHuyenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsThanhThi = table.Column<bool>(type: "bit", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_PHUONGXA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_QUANHUYEN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaLienThong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ThuTuHienThi = table.Column<int>(type: "int", nullable: true),
                    TinhThanhId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DM_QuanH__3214EC2705890FDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_TINHTHANH",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaLienThong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ThuTuHienThi = table.Column<int>(type: "int", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_TINHTHANH", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    TinhId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HuyenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    XaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VaiTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonViId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoDienThoai = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    HoLot = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false, comment: "0: nam, 1: nữ"),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MatKhauSalt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAIKHOAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VAITRO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAITRO_1", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DM_CHUCVU");

            migrationBuilder.DropTable(
                name: "DM_DONVI");

            migrationBuilder.DropTable(
                name: "DM_PHONGBAN");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "PHANQUYEN");

            migrationBuilder.DropTable(
                name: "PHANQUYEN_NHOMQUYEN");

            migrationBuilder.DropTable(
                name: "SYS_CONFIG");

            migrationBuilder.DropTable(
                name: "SYS_MENU");

            migrationBuilder.DropTable(
                name: "SYS_PHUONGXA");

            migrationBuilder.DropTable(
                name: "SYS_QUANHUYEN");

            migrationBuilder.DropTable(
                name: "SYS_TINHTHANH");

            migrationBuilder.DropTable(
                name: "TAIKHOAN");

            migrationBuilder.DropTable(
                name: "VAITRO");
        }
    }
}
