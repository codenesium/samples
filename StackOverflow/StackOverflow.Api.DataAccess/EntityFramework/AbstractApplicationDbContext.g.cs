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

namespace StackOverflowNS.Api.DataAccess
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

		public virtual DbSet<Badges> Badges { get; set; }

		public virtual DbSet<Comments> Comments { get; set; }

		public virtual DbSet<LinkTypes> LinkTypes { get; set; }

		public virtual DbSet<PostHistory> PostHistory { get; set; }

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
			modelBuilder.Entity<Badges>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Badges>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Comments>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Comments>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<LinkTypes>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<LinkTypes>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PostHistory>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PostHistory>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PostHistoryTypes>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PostHistoryTypes>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PostLinks>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PostLinks>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Posts>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Posts>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<PostTypes>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<PostTypes>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Tags>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Tags>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Users>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Users>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Votes>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Votes>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<VoteTypes>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<VoteTypes>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}
}

/*<Codenesium>
    <Hash>8f448c259a2a56052330c37ee4818ca2</Hash>
</Codenesium>*/