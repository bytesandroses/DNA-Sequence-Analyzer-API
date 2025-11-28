using Microsoft.EntityFrameworkCore;

namespace BioSharpApi.Data
{
    public class BioContext : DbContext
    {
        public BioContext(DbContextOptions<BioContext> options) : base(options) { }

        public DbSet<AnalysisRecord> AnalysisHistory { get; set; }
    }
}