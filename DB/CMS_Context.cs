using Microsoft.EntityFrameworkCore;

namespace CmsLocalization.DB
{
    public class CMS_Context : DbContext
    {
        public CMS_Context(DbContextOptions<CMS_Context> options) : base(options) { }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentMapping> ContentMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connect = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CmsLocalizaiton_Database;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data

            modelBuilder.Entity<Language>().HasData(
            new Language()
            {
                Id = 1,
                Name = "Türkçe",
                LanguageCulture = "tr-TR",
                UniqueSeoCode = "tr",
                IsActive = true,
                DisplayOrder = 0
            },
            new Language()
            {
                Id = 2,
                Name = "English",
                LanguageCulture = "en-US",
                UniqueSeoCode = "en",
                IsActive = true,
                DisplayOrder = 1
            });
            #endregion
        }
    }
}