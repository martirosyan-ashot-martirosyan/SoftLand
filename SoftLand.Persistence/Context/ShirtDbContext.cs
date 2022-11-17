using Microsoft.EntityFrameworkCore;
using SoftLand.Domain.Entity;

namespace SoftLand.Persistence.Context
{
    public class ShirtDbContext : DbContext
    {

        public DbSet<DbShirtDataEntity> DbShirtDatas { get; set; }

        public ShirtDbContext(DbContextOptions builder) : base(builder)
        {
            Database.EnsureCreated();
        }
    }
}
