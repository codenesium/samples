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

namespace CADNS.Api.DataAccess
{
	public partial class CallRepositoryMoc
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

		public static Mock<ILogger<CallRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CallRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Call")]
	[Trait("Area", "Repositories")]
	public partial class CallRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CallRepository>> loggerMoc = CallRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CallRepositoryMoc.GetContext();
			var repository = new CallRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<CallRepository>> loggerMoc = CallRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CallRepositoryMoc.GetContext();
			var repository = new CallRepository(loggerMoc.Object, context);

			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CallRepository>> loggerMoc = CallRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CallRepositoryMoc.GetContext();
			var repository = new CallRepository(loggerMoc.Object, context);

			Call entity = new Call();
			entity.SetProperties(default(int), 1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			context.Set<Call>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CallRepository>> loggerMoc = CallRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CallRepositoryMoc.GetContext();
			var repository = new CallRepository(loggerMoc.Object, context);

			var entity = new Call();
			entity.SetProperties(default(int), 1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			await repository.Create(entity);

			var records = await context.Set<Call>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CallRepository>> loggerMoc = CallRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CallRepositoryMoc.GetContext();
			var repository = new CallRepository(loggerMoc.Object, context);
			Call entity = new Call();
			entity.SetProperties(default(int), 1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			context.Set<Call>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Call>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CallRepository>> loggerMoc = CallRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CallRepositoryMoc.GetContext();
			var repository = new CallRepository(loggerMoc.Object, context);
			Call entity = new Call();
			entity.SetProperties(default(int), 1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			context.Set<Call>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Call>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CallRepository>> loggerMoc = CallRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CallRepositoryMoc.GetContext();
			var repository = new CallRepository(loggerMoc.Object, context);
			Call entity = new Call();
			entity.SetProperties(default(int), 1, 1, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			context.Set<Call>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Call>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CallRepository>> loggerMoc = CallRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CallRepositoryMoc.GetContext();
			var repository = new CallRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>8ead695c84a3890c86f64173d360c131</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/