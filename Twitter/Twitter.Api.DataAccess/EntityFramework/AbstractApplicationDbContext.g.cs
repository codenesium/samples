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

namespace TwitterNS.Api.DataAccess
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

		public virtual DbSet<DirectTweet> DirectTweets { get; set; }

		public virtual DbSet<Follower> Followers { get; set; }

		public virtual DbSet<Following> Followings { get; set; }

		public virtual DbSet<Like> Likes { get; set; }

		public virtual DbSet<Location> Locations { get; set; }

		public virtual DbSet<Message> Messages { get; set; }

		public virtual DbSet<Messenger> Messengers { get; set; }

		public virtual DbSet<QuoteTweet> QuoteTweets { get; set; }

		public virtual DbSet<Reply> Replies { get; set; }

		public virtual DbSet<Retweet> Retweets { get; set; }

		public virtual DbSet<Tweet> Tweets { get; set; }

		public virtual DbSet<User> Users { get; set; }

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
			modelBuilder.Entity<DirectTweet>()
			.HasKey(c => new
			{
				c.TweetId,
			});

			modelBuilder.Entity<Follower>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Following>()
			.HasKey(c => new
			{
				c.UserId,
			});

			modelBuilder.Entity<Following>()
			.Property("UserId")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Like>()
			.HasKey(c => new
			{
				c.LikerUserId,
				c.TweetId,
			});

			modelBuilder.Entity<Location>()
			.HasKey(c => new
			{
				c.LocationId,
			});

			modelBuilder.Entity<Message>()
			.HasKey(c => new
			{
				c.MessageId,
			});

			modelBuilder.Entity<Messenger>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Messenger>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<QuoteTweet>()
			.HasKey(c => new
			{
				c.QuoteTweetId,
			});

			modelBuilder.Entity<Reply>()
			.HasKey(c => new
			{
				c.ReplyId,
			});

			modelBuilder.Entity<Retweet>()
			.HasKey(c => new
			{
				c.Id,
			});

			modelBuilder.Entity<Retweet>()
			.Property("Id")
			.ValueGeneratedOnAdd()
			.UseSqlServerIdentityColumn();

			modelBuilder.Entity<Tweet>()
			.HasKey(c => new
			{
				c.TweetId,
			});

			modelBuilder.Entity<User>()
			.HasKey(c => new
			{
				c.UserId,
			});

			var booleanStringConverter = new BoolToStringConverter("N", "Y");
		}
	}

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public virtual ApplicationDbContext CreateDbContext(string[] args)
		{
			string settingsDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Twitter.Api.Web");

			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			IConfigurationRoot configuration = new ConfigurationBuilder()
			                                   .SetBasePath(settingsDirectory)
			                                   .AddJsonFile($"appSettings.{environment}.json")
			                                   .AddEnvironmentVariables()
			                                   .Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("ApplicationDbContext");

			builder.UseSqlServer(connectionString);

			return new ApplicationDbContext(builder.Options);
		}
	}
}

/*<Codenesium>
    <Hash>4993f9dcc5af4570ea7df35f25d16309</Hash>
</Codenesium>*/