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

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class SpecialOfferRepositoryMoc
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

		public static Mock<ILogger<SpecialOfferRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SpecialOfferRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "Repositories")]
	public partial class SpecialOfferRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);

			SpecialOffer entity = new SpecialOffer();
			entity.SetProperties(default(int), "B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SpecialOfferID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);

			var entity = new SpecialOffer();
			entity.SetProperties(default(int), "B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			await repository.Create(entity);

			var records = await context.Set<SpecialOffer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);
			SpecialOffer entity = new SpecialOffer();
			entity.SetProperties(default(int), "B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SpecialOfferID);

			await repository.Update(record);

			var records = await context.Set<SpecialOffer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);
			SpecialOffer entity = new SpecialOffer();
			entity.SetProperties(default(int), "B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<SpecialOffer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);
			SpecialOffer entity = new SpecialOffer();
			entity.SetProperties(default(int), "B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SpecialOfferID);

			var records = await context.Set<SpecialOffer>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>c4bdd69a1ecdc5d9bdb5153d1a9d628e</Hash>
</Codenesium>*/