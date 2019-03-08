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

namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractApplicationDbContext : DbContext
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

		public virtual DbSet<Breed> Breeds { get; set; }

		public virtual DbSet<PaymentType> PaymentTypes { get; set; }

		public virtual DbSet<Pen> Pens { get; set; }

		public virtual DbSet<Pet> Pets { get; set; }

		public virtual DbSet<Sale> Sales { get; set; }

		public virtual DbSet<Species> Species { get; set; }

		/// <summary>
		/// We're overriding SaveChanges because SQLite does not support database computed columns.
		/// ROWGUID is a very common type of column and it does not work with SQLite.
		/// To work around this limitation we detect ROWGUID columns here and set the value.
		/// On SQL Server the database would set the value.
		/// </summary>
		/// <param name="acceptAllChangesOnSuccess">Commit all changes on success</param>
		/// <param name="cancellationToken">Token that can be passed to hault execution</param>
		/// <returns>int</returns>
		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entries = this.ChangeTracker.Entries().Where(e => EntityState.Added.HasFlag(e.State) || EntityState.Modified.HasFlag(e.State));
			if (entries.Any())
			{
				foreach (var entry in entries.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
				{
					var tenantEntity = entry.Properties.FirstOrDefault(x => x.Metadata.Name.ToUpper() == "TENANTID");
					if (tenantEntity != null)
					{
						tenantEntity.CurrentValue = this.TenantId;
					}
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
			modelBuilder.Entity<Breed>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Breed>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PaymentType>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PaymentType>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Pen>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Pen>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Pet>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Pet>()
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

			modelBuilder.Entity<Species>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Species>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}
}

/*<Codenesium>
    <Hash>1cd10d2a40fff4fb2363eae266041659</Hash>
</Codenesium>*/