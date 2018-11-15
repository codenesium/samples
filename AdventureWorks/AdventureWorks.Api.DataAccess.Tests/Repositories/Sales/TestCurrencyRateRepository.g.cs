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
	public partial class CurrencyRateRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CurrencyRateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CurrencyRateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "Repositories")]
	public partial class CurrencyRateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);

			CurrencyRate entity = new CurrencyRate();
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);

			CurrencyRate entity = new CurrencyRate();
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CurrencyRateID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);

			var entity = new CurrencyRate();
			await repository.Create(entity);

			var record = await context.Set<CurrencyRate>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);
			CurrencyRate entity = new CurrencyRate();
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CurrencyRateID);

			await repository.Update(record);

			var modifiedRecord = context.Set<CurrencyRate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);
			CurrencyRate entity = new CurrencyRate();
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new CurrencyRate());

			var modifiedRecord = context.Set<CurrencyRate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);
			CurrencyRate entity = new CurrencyRate();
			context.Set<CurrencyRate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CurrencyRateID);

			CurrencyRate modifiedRecord = await context.Set<CurrencyRate>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<CurrencyRateRepository>> loggerMoc = CurrencyRateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CurrencyRateRepositoryMoc.GetContext();
			var repository = new CurrencyRateRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>27b3df93b6329296761d1b9775e52986</Hash>
</Codenesium>*/