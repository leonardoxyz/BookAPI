using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Library)
            .WithOne(l => l.Address)
            .HasForeignKey<Library>(l => l.AddressId);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
