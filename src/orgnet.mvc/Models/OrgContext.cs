using System.Data.Entity;

namespace orgnet.mvc.Models
{
    public class OrgContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasMany(n => n.Children)
                .WithOptional()
                .HasForeignKey(n => n.ParentId);
        }
    }
}