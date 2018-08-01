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
	public partial class SubscriptionRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SubscriptionRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SubscriptionRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Subscription")]
	[Trait("Area", "Repositories")]
	public partial class SubscriptionRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SubscriptionRepository>> loggerMoc = SubscriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SubscriptionRepositoryMoc.GetContext();
			var repository = new SubscriptionRepository(loggerMoc.Object, context);

			Subscription entity = new Subscription();
			context.Set<Subscription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SubscriptionRepository>> loggerMoc = SubscriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SubscriptionRepositoryMoc.GetContext();
			var repository = new SubscriptionRepository(loggerMoc.Object, context);

			Subscription entity = new Subscription();
			context.Set<Subscription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SubscriptionRepository>> loggerMoc = SubscriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SubscriptionRepositoryMoc.GetContext();
			var repository = new SubscriptionRepository(loggerMoc.Object, context);

			var entity = new Subscription();
			await repository.Create(entity);

			var record = await context.Set<Subscription>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SubscriptionRepository>> loggerMoc = SubscriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SubscriptionRepositoryMoc.GetContext();
			var repository = new SubscriptionRepository(loggerMoc.Object, context);
			Subscription entity = new Subscription();
			context.Set<Subscription>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Subscription>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SubscriptionRepository>> loggerMoc = SubscriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SubscriptionRepositoryMoc.GetContext();
			var repository = new SubscriptionRepository(loggerMoc.Object, context);
			Subscription entity = new Subscription();
			context.Set<Subscription>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Subscription());

			var modifiedRecord = context.Set<Subscription>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SubscriptionRepository>> loggerMoc = SubscriptionRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SubscriptionRepositoryMoc.GetContext();
			var repository = new SubscriptionRepository(loggerMoc.Object, context);
			Subscription entity = new Subscription();
			context.Set<Subscription>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Subscription modifiedRecord = await context.Set<Subscription>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>17fdad0f12397ef42441f25e98a06c3b</Hash>
</Codenesium>*/