# QuanLyKhachSan — Hệ thống quản lý khách sạn

Ứng dụng desktop Windows Forms (C# .NET Framework 4.7.2) dùng **SQLite** làm cơ sở dữ liệu. Giao diện được thiết kế kéo thả bằng Visual Studio WinForms Designer.

## Tính năng

- Đăng nhập bằng tài khoản nhân viên / quản lý.
- Trang chủ: thống kê phòng trống / đang thuê, doanh thu hôm nay và biểu đồ doanh thu 7 ngày gần nhất.
- Quản lý phòng (thêm / sửa / xoá, hiển thị dạng thẻ màu theo tình trạng).
- Quản lý khách hàng (CRUD + tìm kiếm theo tên / CCCD / SĐT).
- Quản lý nhân viên (CRUD + tìm kiếm).
- Lập phiếu thuê phòng (tự tính số đêm và tổng tiền theo đơn giá phòng).
- Báo cáo doanh thu theo khoảng ngày + xuất CSV.

## Yêu cầu môi trường

- Windows 10/11 (hoặc Windows 7+ có .NET Framework 4.7.2).
- Visual Studio 2022 (khuyến nghị) hoặc Visual Studio 2019 16.8+.
- .NET Framework 4.7.2 SDK (thường đã có sẵn khi cài Visual Studio).
- Không cần cài đặt SQLite riêng — thư viện `Microsoft.Data.Sqlite` đã được đóng gói kèm ứng dụng.

## Cách build & chạy

1. Mở file `QuanLyKhachSan.slnx` bằng Visual Studio 2022.
   - Nếu dùng Visual Studio 2019, mở `QuanLyKhachSan/QuanLyKhachSan.csproj` trực tiếp.
2. Chuột phải project → **Restore NuGet Packages** (Visual Studio thường tự restore khi mở).
3. Nhấn `F5` (Debug) hoặc `Ctrl+F5` (Run without debugging).

Khi chạy lần đầu, ứng dụng tự động:
- Tạo file `QuanLyKhachSan.db` (nằm ở thư mục gốc project khi chạy debug, hoặc cùng thư mục với `.exe` khi chạy Release).
- Tạo các bảng `Phong`, `KhachHang`, `NhanVien`, `TaiKhoan`, `PhieuThue`.
- Chèn dữ liệu mẫu: 5 phòng, 2 nhân viên và 2 tài khoản đăng nhập.

## Tài khoản đăng nhập mẫu

| Tên đăng nhập | Mật khẩu | Vai trò  |
| ------------- | -------- | -------- |
| `admin`       | `123`    | Admin    |
| `nhanvien`    | `123`    | NhanVien |

## Cấu trúc thư mục

```
QuanLyKhachSan/
├── QuanLyKhachSan.slnx          # Solution file (VS 2022+)
└── QuanLyKhachSan/
    ├── App.config               # Cấu hình runtime .NET Framework
    ├── QuanLyKhachSan.csproj    # Project file (dùng PackageReference)
    ├── Program.cs               # Entry point
    ├── Entity/                  # Các lớp entity (POCO)
    │   ├── Phong.cs
    │   ├── KhachHang.cs
    │   ├── NhanVien.cs
    │   ├── TaiKhoan.cs
    │   └── PhieuThue.cs
    ├── DAL/                     # Data Access Layer (truy cập SQLite)
    │   ├── KetNoiCSDL.cs        # Tự tạo DB + schema + seed data
    │   ├── PhongDAL.cs
    │   ├── KhachHangDAL.cs
    │   ├── NhanVienDAL.cs
    │   ├── TaiKhoanDAL.cs
    │   └── PhieuThueDAL.cs
    └── Presentation/            # WinForms (giao diện kéo thả)
        ├── FormDangNhap.*       # Đăng nhập
        ├── FormTrangChu.*       # Trang chủ + dashboard
        ├── FormPhong.*          # Quản lý phòng
        ├── FormKhachHang.*      # Quản lý khách hàng
        ├── FormNhanVien.*       # Quản lý nhân viên
        ├── FormPhieuThue.*      # Lập phiếu thuê
        └── FormBaoCao.*         # Báo cáo doanh thu
```

## Cơ sở dữ liệu SQLite

- **Engine**: SQLite (nhúng, không cần server) qua gói `Microsoft.Data.Sqlite.Core` 7.0.0 và `SQLitePCLRaw.bundle_e_sqlite3` 2.1.2.
- **Vị trí file DB**:
  - Khi chạy Debug trong Visual Studio: `QuanLyKhachSan/QuanLyKhachSan.db` (thư mục project).
  - Khi chạy trực tiếp `.exe`: cùng thư mục với `QuanLyKhachSan.exe`.
- **Tạo lại DB từ đầu**: chỉ cần xoá file `QuanLyKhachSan.db`, ứng dụng sẽ tự tạo lại + chèn dữ liệu mẫu ở lần chạy kế tiếp.

### Schema

```sql
CREATE TABLE Phong (
    MaPhong   TEXT PRIMARY KEY,
    TenPhong  TEXT NOT NULL,
    LoaiPhong TEXT,
    Gia       REAL NOT NULL,
    TinhTrang TEXT NOT NULL DEFAULT 'Trống'
);

CREATE TABLE KhachHang (
    MaKH         TEXT PRIMARY KEY,
    HoTen        TEXT NOT NULL,
    CCCD         TEXT,
    SoDienThoai  TEXT,
    DiaChi       TEXT
);

CREATE TABLE NhanVien (
    MaNV         TEXT PRIMARY KEY,
    HoTen        TEXT NOT NULL,
    ChucVu       TEXT,
    SoDienThoai  TEXT,
    DiaChi       TEXT
);

CREATE TABLE TaiKhoan (
    TenDangNhap TEXT PRIMARY KEY,
    MatKhau     TEXT NOT NULL,
    VaiTro      TEXT NOT NULL,
    MaNV        TEXT
);

CREATE TABLE PhieuThue (
    MaPhieu      TEXT PRIMARY KEY,
    MaPhong      TEXT NOT NULL,
    MaKH         TEXT NOT NULL,
    NgayCheckIn  TEXT NOT NULL,
    NgayCheckOut TEXT NOT NULL,
    TongTien     REAL NOT NULL
);
```

## Ghi chú

- Mọi câu lệnh SQL đều dùng tham số hoá (`SqliteParameter`) để chống SQL Injection.
- Lớp `KetNoiCSDL` tự khởi tạo DB và bảng khi chưa tồn tại, nên người dùng cuối không cần thao tác gì với SQLite.
- Giao diện WinForms không nên chỉnh sửa thủ công trong file `.Designer.cs` — luôn mở bằng Visual Studio Designer (kéo thả).
