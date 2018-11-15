using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class AirlineRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<AirlineRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AirlineRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Airline")]
	[Trait("Area", "Repositories")]
	public partial class AirlineRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);

			Airline entity = new Airline();
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);

			Airline entity = new Airline();
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);

			var entity = new Airline();
			await repository.Create(entity);

			var record = await context.Set<Airline>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);
			Airline entity = new Airline();
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Airline>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);
			Airline entity = new Airline();
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Airline());

			var modifiedRecord = context.Set<Airline>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);
			Airline entity = new Airline();
			context.Set<Airline>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Airline modifiedRecord = await context.Set<Airline>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AirlineRepository>> loggerMoc = AirlineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AirlineRepositoryMoc.GetContext();
			var repository = new AirlineRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>d7b1706da6f63f01afcdf8f212ed130e</Hash>
</Codenesium>*/