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
	public partial class DashboardConfigurationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<DashboardConfigurationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<DashboardConfigurationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "DashboardConfiguration")]
	[Trait("Area", "Repositories")]
	public partial class DashboardConfigurationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<DashboardConfigurationRepository>> loggerMoc = DashboardConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DashboardConfigurationRepositoryMoc.GetContext();
			var repository = new DashboardConfigurationRepository(loggerMoc.Object, context);

			DashboardConfiguration entity = new DashboardConfiguration();
			context.Set<DashboardConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<DashboardConfigurationRepository>> loggerMoc = DashboardConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DashboardConfigurationRepositoryMoc.GetContext();
			var repository = new DashboardConfigurationRepository(loggerMoc.Object, context);

			DashboardConfiguration entity = new DashboardConfiguration();
			context.Set<DashboardConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<DashboardConfigurationRepository>> loggerMoc = DashboardConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DashboardConfigurationRepositoryMoc.GetContext();
			var repository = new DashboardConfigurationRepository(loggerMoc.Object, context);

			var entity = new DashboardConfiguration();
			await repository.Create(entity);

			var record = await context.Set<DashboardConfiguration>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<DashboardConfigurationRepository>> loggerMoc = DashboardConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DashboardConfigurationRepositoryMoc.GetContext();
			var repository = new DashboardConfigurationRepository(loggerMoc.Object, context);
			DashboardConfiguration entity = new DashboardConfiguration();
			context.Set<DashboardConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<DashboardConfiguration>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<DashboardConfigurationRepository>> loggerMoc = DashboardConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DashboardConfigurationRepositoryMoc.GetContext();
			var repository = new DashboardConfigurationRepository(loggerMoc.Object, context);
			DashboardConfiguration entity = new DashboardConfiguration();
			context.Set<DashboardConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new DashboardConfiguration());

			var modifiedRecord = context.Set<DashboardConfiguration>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<DashboardConfigurationRepository>> loggerMoc = DashboardConfigurationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = DashboardConfigurationRepositoryMoc.GetContext();
			var repository = new DashboardConfigurationRepository(loggerMoc.Object, context);
			DashboardConfiguration entity = new DashboardConfiguration();
			context.Set<DashboardConfiguration>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			DashboardConfiguration modifiedRecord = await context.Set<DashboardConfiguration>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>0072da98d92d6e77e3b7adbaf294488c</Hash>
</Codenesium>*/