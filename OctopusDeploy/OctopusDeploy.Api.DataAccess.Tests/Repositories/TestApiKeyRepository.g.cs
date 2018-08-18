using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ApiKeyRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ApiKeyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ApiKeyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ApiKey")]
	[Trait("Area", "Repositories")]
	public partial class ApiKeyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ApiKeyRepository>> loggerMoc = ApiKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ApiKeyRepositoryMoc.GetContext();
			var repository = new ApiKeyRepository(loggerMoc.Object, context);

			ApiKey entity = new ApiKey();
			context.Set<ApiKey>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ApiKeyRepository>> loggerMoc = ApiKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ApiKeyRepositoryMoc.GetContext();
			var repository = new ApiKeyRepository(loggerMoc.Object, context);

			ApiKey entity = new ApiKey();
			context.Set<ApiKey>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ApiKeyRepository>> loggerMoc = ApiKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ApiKeyRepositoryMoc.GetContext();
			var repository = new ApiKeyRepository(loggerMoc.Object, context);

			var entity = new ApiKey();
			await repository.Create(entity);

			var record = await context.Set<ApiKey>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ApiKeyRepository>> loggerMoc = ApiKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ApiKeyRepositoryMoc.GetContext();
			var repository = new ApiKeyRepository(loggerMoc.Object, context);
			ApiKey entity = new ApiKey();
			context.Set<ApiKey>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ApiKey>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ApiKeyRepository>> loggerMoc = ApiKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ApiKeyRepositoryMoc.GetContext();
			var repository = new ApiKeyRepository(loggerMoc.Object, context);
			ApiKey entity = new ApiKey();
			context.Set<ApiKey>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ApiKey());

			var modifiedRecord = context.Set<ApiKey>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ApiKeyRepository>> loggerMoc = ApiKeyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ApiKeyRepositoryMoc.GetContext();
			var repository = new ApiKeyRepository(loggerMoc.Object, context);
			ApiKey entity = new ApiKey();
			context.Set<ApiKey>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ApiKey modifiedRecord = await context.Set<ApiKey>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>fe274852f629edc0cd8c47398bb8ccd5</Hash>
</Codenesium>*/