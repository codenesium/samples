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
	public partial class CurrencyRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CurrencyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CurrencyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Currency")]
	[Trait("Area", "Repositories")]
	public partial class CurrencyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CurrencyRepository>> loggerMoc = CurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRepositoryMoc.GetContext();
			var repository = new CurrencyRepository(loggerMoc.Object, context);

			Currency entity = new Currency();
			context.Set<Currency>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CurrencyRepository>> loggerMoc = CurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRepositoryMoc.GetContext();
			var repository = new CurrencyRepository(loggerMoc.Object, context);

			Currency entity = new Currency();
			context.Set<Currency>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CurrencyCode);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CurrencyRepository>> loggerMoc = CurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRepositoryMoc.GetContext();
			var repository = new CurrencyRepository(loggerMoc.Object, context);

			var entity = new Currency();
			await repository.Create(entity);

			var record = await context.Set<Currency>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CurrencyRepository>> loggerMoc = CurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRepositoryMoc.GetContext();
			var repository = new CurrencyRepository(loggerMoc.Object, context);
			Currency entity = new Currency();
			context.Set<Currency>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CurrencyCode);

			await repository.Update(record);

			var modifiedRecord = context.Set<Currency>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CurrencyRepository>> loggerMoc = CurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRepositoryMoc.GetContext();
			var repository = new CurrencyRepository(loggerMoc.Object, context);
			Currency entity = new Currency();
			context.Set<Currency>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Currency());

			var modifiedRecord = context.Set<Currency>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CurrencyRepository>> loggerMoc = CurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRepositoryMoc.GetContext();
			var repository = new CurrencyRepository(loggerMoc.Object, context);
			Currency entity = new Currency();
			context.Set<Currency>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CurrencyCode);

			Currency modifiedRecord = await context.Set<Currency>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CurrencyRepository>> loggerMoc = CurrencyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRepositoryMoc.GetContext();
			var repository = new CurrencyRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete("test_value");
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>1e453884000124637ceffb6bf1f172af</Hash>
</Codenesium>*/