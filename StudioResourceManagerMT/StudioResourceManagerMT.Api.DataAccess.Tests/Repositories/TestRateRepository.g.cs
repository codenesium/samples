using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class RateRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<RateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<RateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "Repositories")]
	public partial class RateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);

			Rate entity = new Rate();
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);

			Rate entity = new Rate();
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);

			var entity = new Rate();
			await repository.Create(entity);

			var record = await context.Set<Rate>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);
			Rate entity = new Rate();
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Rate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);
			Rate entity = new Rate();
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Rate());

			var modifiedRecord = context.Set<Rate>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);
			Rate entity = new Rate();
			context.Set<Rate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Rate modifiedRecord = await context.Set<Rate>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<RateRepository>> loggerMoc = RateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = RateRepositoryMoc.GetContext();
			var repository = new RateRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>7d64239515864da315a2118db145b4ca</Hash>
</Codenesium>*/