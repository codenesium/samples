using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.DataAccess
{
	public partial class BucketRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
		}

		public static Mock<ILogger<BucketRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<BucketRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Bucket")]
	[Trait("Area", "Repositories")]
	public partial class BucketRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BucketRepositoryMoc.GetContext();
			var repository = new BucketRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BucketRepositoryMoc.GetContext();
			var repository = new BucketRepository(loggerMoc.Object, context);

			Bucket entity = new Bucket();
			entity.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			context.Set<Bucket>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BucketRepositoryMoc.GetContext();
			var repository = new BucketRepository(loggerMoc.Object, context);

			var entity = new Bucket();
			entity.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			await repository.Create(entity);

			var records = await context.Set<Bucket>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BucketRepositoryMoc.GetContext();
			var repository = new BucketRepository(loggerMoc.Object, context);
			Bucket entity = new Bucket();
			entity.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			context.Set<Bucket>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Bucket>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BucketRepositoryMoc.GetContext();
			var repository = new BucketRepository(loggerMoc.Object, context);
			Bucket entity = new Bucket();
			entity.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			context.Set<Bucket>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Bucket>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BucketRepositoryMoc.GetContext();
			var repository = new BucketRepository(loggerMoc.Object, context);
			Bucket entity = new Bucket();
			entity.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, "B");
			context.Set<Bucket>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Bucket>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<BucketRepository>> loggerMoc = BucketRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BucketRepositoryMoc.GetContext();
			var repository = new BucketRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>c3190a5660f482125eb773e08bcff0f4</Hash>
</Codenesium>*/