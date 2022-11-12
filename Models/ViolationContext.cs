using Microsoft.EntityFrameworkCore;

namespace RecordingOfViolations.Models
{
    public class ViolationContext : DbContext
    {
        public DbSet<Reason> Reasons => Set<Reason>();
        public DbSet<Violation> Violations => Set<Violation>();
        public DbSet<PaymentСheck> PaymentСhecks => Set<PaymentСheck>();

        public ViolationContext(DbContextOptions<ViolationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
