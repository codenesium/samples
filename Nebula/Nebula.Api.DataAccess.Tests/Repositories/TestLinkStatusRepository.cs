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
	public partial class LinkStatusRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options, null);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
		}

		public static Mock<ILogger<LinkStatusRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LinkStatusRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "LinkStatus")]
	[Trait("Area", "Repositories")]
	public partial class LinkStatusRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
			var repository = new LinkStatusRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
			var repository = new LinkStatusRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
			var repository = new LinkStatusRepository(loggerMoc.Object, context);

			LinkStatus entity = new LinkStatus();
			entity.SetProperties(default(int), "B");
			context.Set<LinkStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
			var repository = new LinkStatusRepository(loggerMoc.Object, context);

			var entity = new LinkStatus();
			entity.SetProperties(default(int), "B");
			await repository.Create(entity);

			var records = await context.Set<LinkStatus>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
			var repository = new LinkStatusRepository(loggerMoc.Object, context);
			LinkStatus entity = new LinkStatus();
			entity.SetProperties(default(int), "B");
			context.Set<LinkStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<LinkStatus>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
			var repository = new LinkStatusRepository(loggerMoc.Object, context);
			LinkStatus entity = new LinkStatus();
			entity.SetProperties(default(int), "B");
			context.Set<LinkStatus>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<LinkStatus>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
			var repository = new LinkStatusRepository(loggerMoc.Object, context);
			LinkStatus entity = new LinkStatus();
			entity.SetProperties(default(int), "B");
			context.Set<LinkStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<LinkStatus>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<LinkStatusRepository>> loggerMoc = LinkStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkStatusRepositoryMoc.GetContext();
			var repository = new LinkStatusRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>eebf6fb73e6fa743279afb0a31af59eb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/