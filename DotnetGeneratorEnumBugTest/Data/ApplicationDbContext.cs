using DotnetGeneratorEnumBugTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetGeneratorEnumBugTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ContainsEnumProperty> Models { get; set; }
    }
}
