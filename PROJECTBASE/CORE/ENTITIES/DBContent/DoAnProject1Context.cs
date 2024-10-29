using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ENTITIES.DBContent;

public partial class DoAnProject1Context : DbContext
{
    public DoAnProject1Context(DbContextOptions<DoAnProject1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<ConversationParticipant> ConversationParticipants { get; set; }

    public virtual DbSet<DM_CHUCVU> DM_CHUCVUs { get; set; }

    public virtual DbSet<DM_DONVI> DM_DONVIs { get; set; }

    public virtual DbSet<DM_PHONGBAN> DM_PHONGBANs { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }

    public virtual DbSet<PHANQUYEN_NHOMQUYEN> PHANQUYEN_NHOMQUYENs { get; set; }

    public virtual DbSet<SYS_CONFIG> SYS_CONFIGs { get; set; }

    public virtual DbSet<SYS_MENU> SYS_MENUs { get; set; }

    public virtual DbSet<SYS_PHUONGXA> SYS_PHUONGXAs { get; set; }

    public virtual DbSet<SYS_QUANHUYEN> SYS_QUANHUYENs { get; set; }

    public virtual DbSet<SYS_TINHTHANH> SYS_TINHTHANHs { get; set; }

    public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

    public virtual DbSet<VAITRO> VAITROs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.Property(e => e.ConversationId).ValueGeneratedNever();
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
        });

        modelBuilder.Entity<ConversationParticipant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId);

            entity.Property(e => e.ParticipantId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DM_CHUCVU>(entity =>
        {
            entity.ToTable("DM_CHUCVU");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.Ma).HasMaxLength(50);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<DM_DONVI>(entity =>
        {
            entity.ToTable("DM_DONVI");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(1000);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiLienHe).HasMaxLength(500);
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DM_PHONGBAN>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PHONGBAN");

            entity.ToTable("DM_PHONGBAN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.Ma).HasMaxLength(50);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("(((((0)-(0))-(0))-(0))-(0.0))");
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Log");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Level)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Logger)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Message).HasMaxLength(4000);
            entity.Property(e => e.Thread)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.MessageId).ValueGeneratedNever();
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasColumnType("text");
        });

        modelBuilder.Entity<PHANQUYEN>(entity =>
        {
            entity.ToTable("PHANQUYEN");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PHANQUYEN_NHOMQUYEN>(entity =>
        {
            entity.ToTable("PHANQUYEN_NHOMQUYEN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<SYS_CONFIG>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYS_CONFIG");
        });

        modelBuilder.Entity<SYS_MENU>(entity =>
        {
            entity.HasKey(e => e.ControllerName).HasName("PK_PHANQUYEN_QUYEN");

            entity.ToTable("SYS_MENU");

            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Controller)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.IsShowMenu).HasDefaultValue(true);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<SYS_PHUONGXA>(entity =>
        {
            entity.ToTable("SYS_PHUONGXA");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Ma).HasMaxLength(100);
            entity.Property(e => e.MaLienThong).HasMaxLength(100);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua).HasMaxLength(50);
            entity.Property(e => e.NguoiTao).HasMaxLength(50);
            entity.Property(e => e.NguoiXoa).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(300);
        });

        modelBuilder.Entity<SYS_QUANHUYEN>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DM_QuanH__3214EC2705890FDD");

            entity.ToTable("SYS_QUANHUYEN");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Ma).HasMaxLength(100);
            entity.Property(e => e.MaLienThong).HasMaxLength(100);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua).HasMaxLength(50);
            entity.Property(e => e.NguoiTao).HasMaxLength(50);
            entity.Property(e => e.NguoiXoa).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(300);
        });

        modelBuilder.Entity<SYS_TINHTHANH>(entity =>
        {
            entity.ToTable("SYS_TINHTHANH");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Ma).HasMaxLength(100);
            entity.Property(e => e.MaLienThong).HasMaxLength(100);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua).HasMaxLength(50);
            entity.Property(e => e.NguoiTao).HasMaxLength(50);
            entity.Property(e => e.NguoiXoa).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(300);
        });

        modelBuilder.Entity<TAIKHOAN>(entity =>
        {
            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AnhDaiDien).HasMaxLength(500);
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasComment("0: nam, 1: nữ");
            entity.Property(e => e.HoLot).HasMaxLength(200);
            entity.Property(e => e.MatKhau).HasMaxLength(500);
            entity.Property(e => e.MatKhauSalt).HasMaxLength(100);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.UserName)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VAITRO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_VAITRO_1");

            entity.ToTable("VAITRO");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
