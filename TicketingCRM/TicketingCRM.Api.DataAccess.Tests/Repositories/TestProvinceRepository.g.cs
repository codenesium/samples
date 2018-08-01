using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class ProvinceRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProvinceRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProvinceRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Province")]
	[Trait("Area", "Repositories")]
	public partial class ProvinceRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProvinceRepository>> loggerMoc = ProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProvinceRepositoryMoc.GetContext();
			var repository = new ProvinceRepository(loggerMoc.Object, context);

			Province entity = new Province();
			context.Set<Province>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProvinceRepository>> loggerMoc = ProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProvinceRepositoryMoc.GetContext();
			var repository = new ProvinceRepository(loggerMoc.Object, context);

			Province entity = new Province();
			context.Set<Province>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProvinceRepository>> loggerMoc = ProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProvinceRepositoryMoc.GetContext();
			var repository = new ProvinceRepository(loggerMoc.Object, context);

			var entity = new Province();
			await repository.Create(entity);

			var record = await context.Set<Province>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProvinceRepository>> loggerMoc = ProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProvinceRepositoryMoc.GetContext();
			var repository = new ProvinceRepository(loggerMoc.Object, context);
			Province entity = new Province();
			context.Set<Province>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Province>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProvinceRepository>> loggerMoc = ProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProvinceRepositoryMoc.GetContext();
			var repository = new ProvinceRepository(loggerMoc.Object, context);
			Province entity = new Province();
			context.Set<Province>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Province());

			var modifiedRecord = context.Set<Province>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProvinceRepository>> loggerMoc = ProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProvinceRepositoryMoc.GetContext();
			var repository = new ProvinceRepository(loggerMoc.Object, context);
			Province entity = new Province();
			context.Set<Province>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Province modifiedRecord = await context.Set<Province>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>819cb5c0e1aaa88f506e5287d0c780fb</Hash>
</Codenesium>*/