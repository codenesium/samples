using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.DataAccess
{
	public partial class VersionInfoRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VersionInfoRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VersionInfoRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "Repositories")]
	public partial class VersionInfoRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);

			VersionInfo entity = new VersionInfo();
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);

			VersionInfo entity = new VersionInfo();
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Version);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);

			var entity = new VersionInfo();
			await repository.Create(entity);

			var record = await context.Set<VersionInfo>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);
			VersionInfo entity = new VersionInfo();
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Version);

			await repository.Update(record);

			var modifiedRecord = context.Set<VersionInfo>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);
			VersionInfo entity = new VersionInfo();
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new VersionInfo());

			var modifiedRecord = context.Set<VersionInfo>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);
			VersionInfo entity = new VersionInfo();
			context.Set<VersionInfo>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Version);

			VersionInfo modifiedRecord = await context.Set<VersionInfo>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VersionInfoRepository>> loggerMoc = VersionInfoRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VersionInfoRepositoryMoc.GetContext();
			var repository = new VersionInfoRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(long));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>09ff3383a4344180b5df1220e30c0d61</Hash>
</Codenesium>*/