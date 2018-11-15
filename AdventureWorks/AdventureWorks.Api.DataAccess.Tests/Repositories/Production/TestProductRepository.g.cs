using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProductRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "Repositories")]
	public partial class ProductRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);

			Product entity = new Product();
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);

			Product entity = new Product();
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);

			var entity = new Product();
			await repository.Create(entity);

			var record = await context.Set<Product>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);
			Product entity = new Product();
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Product>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);
			Product entity = new Product();
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Product());

			var modifiedRecord = context.Set<Product>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);
			Product entity = new Product();
			context.Set<Product>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductID);

			Product modifiedRecord = await context.Set<Product>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductRepository>> loggerMoc = ProductRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductRepositoryMoc.GetContext();
			var repository = new ProductRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>5151eaecd812924310e0b8913dbea450</Hash>
</Codenesium>*/