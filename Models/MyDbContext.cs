using EFCoreFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<EFCoreFirst.Models.Customer> Customer { get; set; } = default!;
    }
}
