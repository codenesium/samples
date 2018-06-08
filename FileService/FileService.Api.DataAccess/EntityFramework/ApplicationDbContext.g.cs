using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FileServiceNS.Api.DataAccess
{
        public partial class ApplicationDbContext: DbContext
        {
                public Guid UserId { get; private set; }

                public int TenantId { get; private set; }

                public ApplicationDbContext(DbContextOptions options)
                        : base(options)
                {
                }

                protected override void OnConfiguring(DbContextOptionsBuilder options)
                {
                        base.OnConfiguring(options);
                }

                public void SetUserId(Guid userId)
                {
                        if (userId == default (Guid))
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

                public virtual DbSet<Bucket> Buckets { get; set; }

                public virtual DbSet<File> Files { get; set; }

                public virtual DbSet<FileType> FileTypes { get; set; }

                public virtual DbSet<VersionInfo> VersionInfoes { get; set; }
        }

        public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
        {
                public ApplicationDbContext CreateDbContext(string[] args)
                {
                        string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "FileService.Api.Web");

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
    <Hash>4dd4bc3daa0e7c9b09cd322e3b463c99</Hash>
</Codenesium>*/