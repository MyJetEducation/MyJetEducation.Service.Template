using Microsoft.EntityFrameworkCore;
using MyJetWallet.Sdk.Postgres;
using MyJetWallet.Sdk.Service;
using Service.AssetsDictionary.Domain.Models;

namespace Service.AssetsDictionary.Postgres
{
    public class DatabaseContext : MyDbContext
    {
        public const string Schema = "education";
        private const string AssetsDictionaryTableName = "assetsdictionary";

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AssetsDictionaryEntity> AssetsDictionarEntities { get; set; }

        public static DatabaseContext Create(DbContextOptionsBuilder<DatabaseContext> options)
        {
            MyTelemetry.StartActivity($"Database context {Schema}")?.AddTag("db-schema", Schema);

            return new DatabaseContext(options.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            SetUserInfoEntityEntry(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetUserInfoEntityEntry(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetsDictionaryEntity>().ToTable(AssetsDictionaryTableName);
            modelBuilder.Entity<AssetsDictionaryEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<AssetsDictionaryEntity>().Property(e => e.Date).IsRequired();
            modelBuilder.Entity<AssetsDictionaryEntity>().Property(e => e.Value);
            modelBuilder.Entity<AssetsDictionaryEntity>().HasKey(e => e.Id);
        }
    }
}
