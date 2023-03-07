using api.Data.Common;
using api.Data.Models;
using api.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Emit;

namespace api.Data
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

        public DbSet<PizzaType> PizzaTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderPizza> OrderPizzas { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInformation();
            this.ApplyDeletableEntity();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            this.ApplyAuditInformation();
            this.ApplyDeletableEntity();

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
            .Property(o => o.Status)
            .HasConversion(
                v => v.ToString(),
                v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v)
            );

            builder.Entity<Order>()
            .HasIndex(o => o.CustomerId);

            builder.Entity<OrderPizza>()
            .HasKey(op => new { op.OrderId, op.PizzaId });
        }

        private void ApplyAuditInformation()
            => this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IEntity &&
                    (e.State == EntityState.Added ||
                     e.State == EntityState.Modified))
                .ToList()
                .ForEach(entry =>
                {
                    var entity = (IEntity)entry.Entity;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        entity.ModifiedOn = DateTime.UtcNow;
                    }
                });

        private void ApplyDeletableEntity()
            => this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IDeletableEntity &&
                    e.State == EntityState.Deleted)
                .ToList()
                .ForEach(entry =>
                {
                    var entity = (IDeletableEntity)entry.Entity;

                    entity.IsDeleted = true;
                    entity.DeletedOn = DateTime.UtcNow;
                    entry.State = EntityState.Modified;
                });
    }
}
