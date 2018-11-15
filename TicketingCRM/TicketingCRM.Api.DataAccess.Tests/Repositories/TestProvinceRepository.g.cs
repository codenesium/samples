using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
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
		public async void DeleteFound()
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

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ProvinceRepository>> loggerMoc = ProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProvinceRepositoryMoc.GetContext();
			var repository = new ProvinceRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>902af6b627ced34d48b92c8251f13266</Hash>
</Codenesium>*/