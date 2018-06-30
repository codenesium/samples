using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace TicketingCRMNS.Api.DataAccess
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

                public virtual DbSet<Admin> Admins { get; set; }

                public virtual DbSet<City> Cities { get; set; }

                public virtual DbSet<Country> Countries { get; set; }

                public virtual DbSet<Customer> Customers { get; set; }

                public virtual DbSet<Event> Events { get; set; }

                public virtual DbSet<Province> Provinces { get; set; }

                public virtual DbSet<Sale> Sales { get; set; }

                public virtual DbSet<SaleTickets> SaleTickets { get; set; }

                public virtual DbSet<Ticket> Tickets { get; set; }

                public virtual DbSet<TicketStatus> TicketStatus { get; set; }

                public virtual DbSet<Transaction> Transactions { get; set; }

                public virtual DbSet<TransactionStatus> TransactionStatus { get; set; }

                public virtual DbSet<Venue> Venues { get; set; }

                protected override void OnConfiguring(DbContextOptionsBuilder options)
                {
                        base.OnConfiguring(options);
                }
        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
                public ApplicationDbContext CreateDbContext(string[] args)
                {
                        string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "TicketingCRM.Api.Web");

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
    <Hash>81dcf3a9788d0d9a48c551b7f835dd57</Hash>
</Codenesium>*/