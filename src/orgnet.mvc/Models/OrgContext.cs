using System.Data.Entity;

namespace orgnet.mvc.Models
{
    public class OrgContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }
    }
}