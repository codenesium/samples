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

namespace NebulaNS.Api.DataAccess
{
	public partial class LinkRepositoryMoc
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

		public static Mock<ILogger<LinkRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LinkRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Link")]
	[Trait("Area", "Repositories")]
	public partial class LinkRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);

			Link entity = new Link();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", 2, "B", "B", 2);
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);

			var entity = new Link();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", 2, "B", "B", 2);
			await repository.Create(entity);

			var records = await context.Set<Link>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);
			Link entity = new Link();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", 2, "B", "B", 2);
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Link>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);
			Link entity = new Link();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", 2, "B", "B", 2);
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Link>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);
			Link entity = new Link();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", 2, "B", "B", 2);
			context.Set<Link>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Link>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<LinkRepository>> loggerMoc = LinkRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkRepositoryMoc.GetContext();
			var repository = new LinkRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>dd5d8c1ae29b6a39b4968724cb912109</Hash>
</Codenesium>*/