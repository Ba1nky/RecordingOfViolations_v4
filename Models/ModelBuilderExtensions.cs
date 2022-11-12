using Microsoft.EntityFrameworkCore;

namespace RecordingOfViolations.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Violation>()
                .HasOne(p => p.Reason)
                .WithMany(u => u.Violations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PaymentСheck>()
                .HasOne(p => p.Violation)
                .WithMany(t => t.PaymentСhecks)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Reason[] reasons =
            {
                new Reason
                {
                    ReasonId = 1,
                    Name = "Порушення правил користування ременями безпеки або мотошоломами"
                },
                new Reason
                {
                    ReasonId = 2,
                    Name = "Нетверезий стан"
                },
                new Reason
                {
                    ReasonId = 3,
                    Name = "Порушення правил перевезення дітей"
                },
                new Reason
                {
                    ReasonId = 4,
                    Name = "Порушення правил зупинки маршрутних таксі"
                }
            };

            Violation[] violations =
            {
                 new Violation {
                        ViolationId = 1,
                        Address = "вулиця Інститутська, 22",
                        Policeman = "Кукурудза Валерій",
                        Offender = "Cпівак Олег",
                        ReasonId = 3,
                        Price = 1750,
                        Date = DateTime.Now.AddDays(-8),
                 },
                 new Violation {
                        ViolationId = 2,
                        Address = "Львівське шосе, 38/1",
                        Policeman = "Щур Сергій",
                        Offender = "Ткачук Петро",
                        ReasonId = 1,
                        Price = 510,
                        Date = DateTime.Now.AddDays(-23),
                 },
                 new Violation {
                        ViolationId = 3,
                        Address = "вулиця Соборна, 11",
                        Policeman = "Щур Сергій",
                        Offender = "Олійник Яна",
                        ReasonId = 4,
                        Price = 750,
                        Date = DateTime.Now.AddDays(-2),
                 },
                 new Violation {
                        ViolationId = 4,
                        Address = "вулиця Трудова, 6А",
                        Policeman = "Кукурудза Валерій",
                        Offender = "Пристувчук Олександр",
                        ReasonId = 2,
                        Price = 15000,
                        Date = DateTime.Now.AddDays(-14),
                 }
            };

            modelBuilder.Entity<Reason>().HasData(reasons);
            modelBuilder.Entity<Violation>().HasData(violations);
        }
    }
}
