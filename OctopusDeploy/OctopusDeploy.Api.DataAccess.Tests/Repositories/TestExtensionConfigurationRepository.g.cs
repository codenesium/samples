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
	public partial class ExtensionConfigurationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ExtensionConfigurationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ExtensionConfigurationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ExtensionConfiguration")]
	[Trait("Area", "Repositories")]
	public partial class ExtensionConfigurationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ExtensionConfigurationRepository>> loggerMoc = ExtensionConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ExtensionConfigurationRepositoryMoc.GetContext();
			var repository = new ExtensionConfigurationRepository(loggerMoc.Object, context);

			ExtensionConfiguration entity = new ExtensionConfiguration();
			context.Set<ExtensionConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ExtensionConfigurationRepository>> loggerMoc = ExtensionConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ExtensionConfigurationRepositoryMoc.GetContext();
			var repository = new ExtensionConfigurationRepository(loggerMoc.Object, context);

			ExtensionConfiguration entity = new ExtensionConfiguration();
			context.Set<ExtensionConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ExtensionConfigurationRepository>> loggerMoc = ExtensionConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ExtensionConfigurationRepositoryMoc.GetContext();
			var repository = new ExtensionConfigurationRepository(loggerMoc.Object, context);

			var entity = new ExtensionConfiguration();
			await repository.Create(entity);

			var record = await context.Set<ExtensionConfiguration>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ExtensionConfigurationRepository>> loggerMoc = ExtensionConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ExtensionConfigurationRepositoryMoc.GetContext();
			var repository = new ExtensionConfigurationRepository(loggerMoc.Object, context);
			ExtensionConfiguration entity = new ExtensionConfiguration();
			context.Set<ExtensionConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ExtensionConfiguration>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ExtensionConfigurationRepository>> loggerMoc = ExtensionConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ExtensionConfigurationRepositoryMoc.GetContext();
			var repository = new ExtensionConfigurationRepository(loggerMoc.Object, context);
			ExtensionConfiguration entity = new ExtensionConfiguration();
			context.Set<ExtensionConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ExtensionConfiguration());

			var modifiedRecord = context.Set<ExtensionConfiguration>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ExtensionConfigurationRepository>> loggerMoc = ExtensionConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ExtensionConfigurationRepositoryMoc.GetContext();
			var repository = new ExtensionConfigurationRepository(loggerMoc.Object, context);
			ExtensionConfiguration entity = new ExtensionConfiguration();
			context.Set<ExtensionConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ExtensionConfiguration modifiedRecord = await context.Set<ExtensionConfiguration>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>504cdaa45f1327b3a6294aab36e43c50</Hash>
</Codenesium>*/