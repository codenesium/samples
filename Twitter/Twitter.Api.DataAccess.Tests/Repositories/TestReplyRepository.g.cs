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

namespace TwitterNS.Api.DataAccess
{
	public partial class ReplyRepositoryMoc
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

		public static Mock<ILogger<ReplyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ReplyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Reply")]
	[Trait("Area", "Repositories")]
	public partial class ReplyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);

			Reply entity = new Reply();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ReplyId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);

			var entity = new Reply();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			await repository.Create(entity);

			var records = await context.Set<Reply>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);
			Reply entity = new Reply();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ReplyId);

			await repository.Update(record);

			var records = await context.Set<Reply>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);
			Reply entity = new Reply();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Reply>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);
			Reply entity = new Reply();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			context.Set<Reply>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ReplyId);

			var records = await context.Set<Reply>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ReplyRepository>> loggerMoc = ReplyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ReplyRepositoryMoc.GetContext();
			var repository = new ReplyRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>c519cae40816ca58951d4d29b57f135e</Hash>
</Codenesium>*/