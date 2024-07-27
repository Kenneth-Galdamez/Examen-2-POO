using ExamenPoo2KennethGaldamez.Database.Entities;
using ExamenPoo2KennethGaldamez.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ExamenPoo2KennethGaldamez.Database
{
    public class Examen2Context : DbContext 
    {
        private readonly IAuthService _authService;

        public Examen2Context(
            DbContextOptions options, 
            IAuthService authService
            ) : base(options)
        {
            this._authService = authService;
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified
                ));

            foreach (var entry in entries) 
            {
                var entity = entry.Entity as BaseEntity;
                if (entity != null) 
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = _authService.GetUserId();
                        entity.CreatedDate = DateTime.Now;
                    }
                    else 
                    {
                        entity.UpdatedBy = _authService.GetUserId();
                        entity.UpdatedDate = DateTime.Now;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<ProspectEntity> Prospects { get; set; }
  
    }
}
