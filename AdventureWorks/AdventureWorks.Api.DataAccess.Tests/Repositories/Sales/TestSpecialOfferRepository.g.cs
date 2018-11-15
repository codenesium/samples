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
	public partial class SpecialOfferRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SpecialOfferRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SpecialOfferRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "Repositories")]
	public partial class SpecialOfferRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);

			SpecialOffer entity = new SpecialOffer();
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);

			SpecialOffer entity = new SpecialOffer();
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SpecialOfferID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);

			var entity = new SpecialOffer();
			await repository.Create(entity);

			var record = await context.Set<SpecialOffer>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);
			SpecialOffer entity = new SpecialOffer();
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.SpecialOfferID);

			await repository.Update(record);

			var modifiedRecord = context.Set<SpecialOffer>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);
			SpecialOffer entity = new SpecialOffer();
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SpecialOffer());

			var modifiedRecord = context.Set<SpecialOffer>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);
			SpecialOffer entity = new SpecialOffer();
			context.Set<SpecialOffer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.SpecialOfferID);

			SpecialOffer modifiedRecord = await context.Set<SpecialOffer>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SpecialOfferRepository>> loggerMoc = SpecialOfferRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SpecialOfferRepositoryMoc.GetContext();
			var repository = new SpecialOfferRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>4ab7fb918936f4400f86bfb99b538aa2</Hash>
</Codenesium>*/