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
	public partial class SalesTaxRateRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SalesTaxRateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SalesTaxRateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "Repositories")]
	public partial class SalesTaxRateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesTaxRateID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			var entity = new SalesTaxRate();
			await repository.Create(entity);

			var record = await context.Set<SalesTaxRate>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SalesTaxRateID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SalesTaxRate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SalesTaxRate());

			var modifiedRecord = context.Set<SalesTaxRate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);
			SalesTaxRate entity = new SalesTaxRate();
			context.Set<SalesTaxRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SalesTaxRateID);

			SalesTaxRate modifiedRecord = await context.Set<SalesTaxRate>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SalesTaxRateRepository>> loggerMoc = SalesTaxRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SalesTaxRateRepositoryMoc.GetContext();
			var repository = new SalesTaxRateRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>ca830054dafc42928ec2af4a4fa00b52</Hash>
</Codenesium>*/