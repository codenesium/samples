using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class ApplicationDbContext : DbContext
        {
                public Guid UserId { get; private set; }

                public int TenantId { get; private set; }

                public ApplicationDbContext(DbContextOptions options)
                        : base(options)
                {
                }

                public void SetUserId(Guid userId)
                {
                        if (userId == default(Guid))
                        {
                                throw new ArgumentException("UserId cannot be a default value");
                        }

                        this.UserId = userId;
                }

                public void SetTenantId(int tenantId)
                {
                        if (tenantId <= 0)
                        {
                                throw new ArgumentException("TenantId must be greater than 0");
                        }

                        this.TenantId = tenantId;
                }

                public virtual DbSet<Badges> Badges { get; set; }

                public virtual DbSet<Comments> Comments { get; set; }

                public virtual DbSet<LinkTypes> LinkTypes { get; set; }

                public virtual DbSet<PostHistory> PostHistories { get; set; }

                public virtual DbSet<PostHistoryTypes> PostHistoryTypes { get; set; }

                public virtual DbSet<PostLinks> PostLinks { get; set; }

                public virtual DbSet<Posts> Posts { get; set; }

                public virtual DbSet<PostTypes> PostTypes { get; set; }

                public virtual DbSet<Tags> Tags { get; set; }

                public virtual DbSet<Users> Users { get; set; }

                public virtual DbSet<Votes> Votes { get; set; }

                public virtual DbSet<VoteTypes> VoteTypes { get; set; }

                /// <summary>
                /// We're overriding SaveChanges because SQLite does not support database computed columns.
                /// RowVersion is a very common type of column and it does not work with SQLite.
                /// To work around this limitation we detect RowVersion columns here and set the value.
                /// On SQL Server the database would set the value.
                /// </summary>
                /// <returns>int</returns>
                public override int SaveChanges()
                {
                        var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State));
                        if (entries.Any())
                        {
                                foreach (var createdEntry in entries)
                                {
                                        var entity = createdEntry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "ROWVERSION");
                                        if (entity != null && entity.Metadata.ClrType == typeof(Guid) && (Guid)entity.CurrentValue != default(Guid))
                                        {
                                                entity.CurrentValue = Guid.NewGuid();
                                        }
                                }
                        }

                        return base.SaveChanges();
                }

                protected override void OnConfiguring(DbContextOptionsBuilder options)
                {
                        base.OnConfiguring(options);
                }
        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
                public ApplicationDbContext CreateDbContext(string[] args)
                {
                        string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "StackOverflow.Api.Web");

                        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                        IConfigurationRoot configuration = new ConfigurationBuilder()
                                                           .SetBasePath(settingsDirectory)
                                                           .AddJsonFile($"appsettings.{environment}.json")
                                                           .Build();

                        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

                        var connectionString = configuration.GetConnectionString("ApplicationDbContext");

                        builder.UseSqlServer(connectionString);

                        return new ApplicationDbContext(builder.Options);
                }
        }
}

/*<Codenesium>
    <Hash>a57d6e94b471f5f58cf3d7f65cf15400</Hash>
</Codenesium>*/