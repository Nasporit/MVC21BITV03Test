using System;
using System.Collections.Generic;

namespace EFCoreFirst.Models;

public partial class HangHoa
{
    public int MaHh { get; set; }

    public string TenHh { get; set; } = null!;

    public double DonGia { get; set; }

    public int SoLuong { get; set; }

    public string Hinh { get; set; } = null!;

    public int? MaLoai { get; set; }

    public virtual Loai? MaLoaiNavigation { get; set; }
}
