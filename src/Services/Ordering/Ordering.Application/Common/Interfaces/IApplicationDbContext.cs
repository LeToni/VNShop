namespace Ordering.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Order> Orders { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
