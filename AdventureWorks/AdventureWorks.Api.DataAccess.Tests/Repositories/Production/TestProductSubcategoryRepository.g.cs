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
	public partial class ProductSubcategoryRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProductSubcategoryRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProductSubcategoryRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "Repositories")]
	public partial class ProductSubcategoryRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);

			ProductSubcategory entity = new ProductSubcategory();
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);

			ProductSubcategory entity = new ProductSubcategory();
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductSubcategoryID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);

			var entity = new ProductSubcategory();
			await repository.Create(entity);

			var record = await context.Set<ProductSubcategory>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);
			ProductSubcategory entity = new ProductSubcategory();
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductSubcategoryID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductSubcategory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);
			ProductSubcategory entity = new ProductSubcategory();
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductSubcategory());

			var modifiedRecord = context.Set<ProductSubcategory>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);
			ProductSubcategory entity = new ProductSubcategory();
			context.Set<ProductSubcategory>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductSubcategoryID);

			ProductSubcategory modifiedRecord = await context.Set<ProductSubcategory>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProductSubcategoryRepository>> loggerMoc = ProductSubcategoryRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductSubcategoryRepositoryMoc.GetContext();
			var repository = new ProductSubcategoryRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a485cd3c986a0b1cfa8f003bcd038516</Hash>
</Codenesium>*/