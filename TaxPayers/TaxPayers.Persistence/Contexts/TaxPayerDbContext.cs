using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaxPayers.Domain.Common;
using TaxPayers.Domain.Common.Interfaces;
using TaxPayers.Domain.Entities;

namespace TaxPayers.Persistence.Contexts
{
    public class TaxPayerDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public TaxPayerDbContext(DbContextOptions<TaxPayerDbContext> options,
          IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }


        #region Tables

        public DbSet<TaxPayer> TaxPayer => Set<TaxPayer>();
        public DbSet<TaxReceipt> TaxReceipt => Set<TaxReceipt>();

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
