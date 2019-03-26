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
	public partial class ShoppingCartItemRepositoryMoc
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

		public static Mock<ILogger<ShoppingCartItemRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ShoppingCartItemRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "Repositories")]
	public partial class ShoppingCartItemRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
			var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
			var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
			var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

			ShoppingCartItem entity = new ShoppingCartItem();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			context.Set<ShoppingCartItem>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ShoppingCartItemID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
			var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

			var entity = new ShoppingCartItem();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			await repository.Create(entity);

			var records = await context.Set<ShoppingCartItem>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
			var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);
			ShoppingCartItem entity = new ShoppingCartItem();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			context.Set<ShoppingCartItem>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ShoppingCartItemID);

			await repository.Update(record);

			var records = await context.Set<ShoppingCartItem>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
			var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);
			ShoppingCartItem entity = new ShoppingCartItem();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			context.Set<ShoppingCartItem>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ShoppingCartItem>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
			var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);
			ShoppingCartItem entity = new ShoppingCartItem();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			context.Set<ShoppingCartItem>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ShoppingCartItemID);

			var records = await context.Set<ShoppingCartItem>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ShoppingCartItemRepository>> loggerMoc = ShoppingCartItemRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ShoppingCartItemRepositoryMoc.GetContext();
			var repository = new ShoppingCartItemRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>e171e9d3763b35e6b0578e45226e8005</Hash>
</Codenesium>*/