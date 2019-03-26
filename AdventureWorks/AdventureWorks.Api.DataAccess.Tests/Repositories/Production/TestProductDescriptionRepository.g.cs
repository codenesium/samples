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
	public partial class ProductDescriptionRepositoryMoc
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

		public static Mock<ILogger<ProductDescriptionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductDescriptionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "Repositories")]
	public partial class ProductDescriptionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);

			ProductDescription entity = new ProductDescription();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductDescription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductDescriptionID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);

			var entity = new ProductDescription();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			await repository.Create(entity);

			var records = await context.Set<ProductDescription>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);
			ProductDescription entity = new ProductDescription();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductDescription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductDescriptionID);

			await repository.Update(record);

			var records = await context.Set<ProductDescription>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);
			ProductDescription entity = new ProductDescription();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductDescription>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<ProductDescription>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);
			ProductDescription entity = new ProductDescription();
			entity.SetProperties(default(int), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<ProductDescription>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductDescriptionID);

			var records = await context.Set<ProductDescription>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>53635b75d9cc39bb269beea3a830c2c6</Hash>
</Codenesium>*/