using bookreview.infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace bookreview.infrastructure.Repository.EFCore
{
	public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Database context is used to handle the database state, such as any table or data fixes.
        /// Will not be used to handling any database queries as that will be handled by the
        /// Dapper Repository.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasKey(o => o.AuthorId);

            modelBuilder.Entity<Author>().Property(x => x.ModifiedDate).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Book>()
                .HasKey(o => o.BookId);

            modelBuilder.Entity<Publisher>()
                .HasKey(o => o.PublisherId);

            modelBuilder.Entity<Book>()
                .HasOne(o => o.Publisher)
                .WithMany(o => o.Books)
                .HasForeignKey(o => o.PublisherId);

            modelBuilder.Entity<Review>();
        }
    }
}
