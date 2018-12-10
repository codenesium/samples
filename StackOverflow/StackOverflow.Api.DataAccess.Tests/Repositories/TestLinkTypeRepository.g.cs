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

namespace StackOverflowNS.Api.DataAccess
{
	public partial class LinkTypeRepositoryMoc
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

		public static Mock<ILogger<LinkTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LinkTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "LinkType")]
	[Trait("Area", "Repositories")]
	public partial class LinkTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);

			LinkType entity = new LinkType();
			entity.SetProperties(2, "B");
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);

			var entity = new LinkType();
			entity.SetProperties(2, "B");
			await repository.Create(entity);

			var records = await context.Set<LinkType>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);
			LinkType entity = new LinkType();
			entity.SetProperties(2, "B");
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<LinkType>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);
			LinkType entity = new LinkType();
			entity.SetProperties(2, "B");
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<LinkType>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);
			LinkType entity = new LinkType();
			entity.SetProperties(2, "B");
			context.Set<LinkType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<LinkType>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<LinkTypeRepository>> loggerMoc = LinkTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LinkTypeRepositoryMoc.GetContext();
			var repository = new LinkTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>012e13cf2f327b3893300357fabf61ff</Hash>
</Codenesium>*/