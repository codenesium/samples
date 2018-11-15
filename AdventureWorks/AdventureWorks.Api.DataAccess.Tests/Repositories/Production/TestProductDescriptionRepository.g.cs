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
	public partial class ProductDescriptionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
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

			ProductDescription entity = new ProductDescription();
			context.Set<ProductDescription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);

			ProductDescription entity = new ProductDescription();
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
			await repository.Create(entity);

			var record = await context.Set<ProductDescription>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);
			ProductDescription entity = new ProductDescription();
			context.Set<ProductDescription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ProductDescriptionID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ProductDescription>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);
			ProductDescription entity = new ProductDescription();
			context.Set<ProductDescription>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ProductDescription());

			var modifiedRecord = context.Set<ProductDescription>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ProductDescriptionRepository>> loggerMoc = ProductDescriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProductDescriptionRepositoryMoc.GetContext();
			var repository = new ProductDescriptionRepository(loggerMoc.Object, context);
			ProductDescription entity = new ProductDescription();
			context.Set<ProductDescription>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ProductDescriptionID);

			ProductDescription modifiedRecord = await context.Set<ProductDescription>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
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
    <Hash>dd863cf7e39a42e9582ca2f4a2e1868c</Hash>
</Codenesium>*/