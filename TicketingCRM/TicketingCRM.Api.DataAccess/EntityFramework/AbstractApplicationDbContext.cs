using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public abstract class AbstractApplicationDbContext : IdentityDbContext<AuthUser>
	{
		public Guid UserId { get; private set; }

		public int TenantId { get; private set; }

		public AbstractApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public virtual void SetUserId(Guid userId)
		{
			this.UserId = userId;
		}

		public virtual void SetTenantId(int tenantId)
		{
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

		/// <summary>
		/// We're overriding SaeChanges to set the tenantId and the IsDeleted columns to make the system work wih multi-tenancy and soft deleted.
		/// We work under the assumption that if you have columns named tenantId then you're multi-tenant and IsDeleted mean you want soft deletes
		/// </summary>
		/// <param name="acceptAllChangesOnSuccess">Commit all changes on success</param>
		/// <param name="cancellationToken">Token that can be passed to hault execution</param>
		/// <returns>int</returns>
		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State) || EntityState.Modified.HasFlag(e.State));
			foreach (var entry in entries)
			{
				var tenantEntity = entry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "TENANTID");
				if (tenantEntity != null)
				{
					tenantEntity.CurrentValue = this.TenantId;
				}
			}

			var deletedEntries = this.ChangeTracker.Entries().Where(e => EntityState.Deleted.HasFlag(e.State));
			foreach (var entry in deletedEntries)
			{
				var softDeleteEntity = entry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "ISDELETED");
				if (softDeleteEntity != null)
				{
					softDeleteEntity.CurrentValue = true;
					entry.State = EntityState.Modified;
				}
			}

			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			base.OnConfiguring(options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Admin>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Admin>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<City>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<City>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Country>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Country>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Customer>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Customer>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Event>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Event>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Province>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Province>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Sale>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Sale>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<SaleTickets>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<SaleTickets>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Ticket>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Ticket>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<TicketStatus>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<TicketStatus>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Transaction>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Transaction>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<TransactionStatus>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<TransactionStatus>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Venue>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Venue>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
			base.OnModelCreating(modelBuilder);
		}
	}

	// this is needed to make Entity Framework migrations command line tools work
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public virtual ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "TicketingCRM.Api.Web");

			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile($"appSettings.{environment}.json")
			                                   .AddEnvironmentVariables()
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options, null);
		}
	}
}

/*<Codenesium>
    <Hash>46f7d5b381c6b3983c9c3fe0ae6c1659</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/