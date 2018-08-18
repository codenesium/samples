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
	public partial class ConfigurationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ConfigurationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ConfigurationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Configuration")]
	[Trait("Area", "Repositories")]
	public partial class ConfigurationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ConfigurationRepository>> loggerMoc = ConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ConfigurationRepositoryMoc.GetContext();
			var repository = new ConfigurationRepository(loggerMoc.Object, context);

			Configuration entity = new Configuration();
			context.Set<Configuration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ConfigurationRepository>> loggerMoc = ConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ConfigurationRepositoryMoc.GetContext();
			var repository = new ConfigurationRepository(loggerMoc.Object, context);

			Configuration entity = new Configuration();
			context.Set<Configuration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ConfigurationRepository>> loggerMoc = ConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ConfigurationRepositoryMoc.GetContext();
			var repository = new ConfigurationRepository(loggerMoc.Object, context);

			var entity = new Configuration();
			await repository.Create(entity);

			var record = await context.Set<Configuration>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ConfigurationRepository>> loggerMoc = ConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ConfigurationRepositoryMoc.GetContext();
			var repository = new ConfigurationRepository(loggerMoc.Object, context);
			Configuration entity = new Configuration();
			context.Set<Configuration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Configuration>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ConfigurationRepository>> loggerMoc = ConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ConfigurationRepositoryMoc.GetContext();
			var repository = new ConfigurationRepository(loggerMoc.Object, context);
			Configuration entity = new Configuration();
			context.Set<Configuration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Configuration());

			var modifiedRecord = context.Set<Configuration>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ConfigurationRepository>> loggerMoc = ConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ConfigurationRepositoryMoc.GetContext();
			var repository = new ConfigurationRepository(loggerMoc.Object, context);
			Configuration entity = new Configuration();
			context.Set<Configuration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Configuration modifiedRecord = await context.Set<Configuration>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f372fdad0857ca4cb831627d20f9335f</Hash>
</Codenesium>*/