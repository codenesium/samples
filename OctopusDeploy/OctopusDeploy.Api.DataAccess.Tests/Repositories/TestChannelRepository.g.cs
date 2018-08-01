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
	public partial class ChannelRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ChannelRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ChannelRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Channel")]
	[Trait("Area", "Repositories")]
	public partial class ChannelRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ChannelRepository>> loggerMoc = ChannelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChannelRepositoryMoc.GetContext();
			var repository = new ChannelRepository(loggerMoc.Object, context);

			Channel entity = new Channel();
			context.Set<Channel>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ChannelRepository>> loggerMoc = ChannelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChannelRepositoryMoc.GetContext();
			var repository = new ChannelRepository(loggerMoc.Object, context);

			Channel entity = new Channel();
			context.Set<Channel>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ChannelRepository>> loggerMoc = ChannelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChannelRepositoryMoc.GetContext();
			var repository = new ChannelRepository(loggerMoc.Object, context);

			var entity = new Channel();
			await repository.Create(entity);

			var record = await context.Set<Channel>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ChannelRepository>> loggerMoc = ChannelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChannelRepositoryMoc.GetContext();
			var repository = new ChannelRepository(loggerMoc.Object, context);
			Channel entity = new Channel();
			context.Set<Channel>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Channel>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ChannelRepository>> loggerMoc = ChannelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChannelRepositoryMoc.GetContext();
			var repository = new ChannelRepository(loggerMoc.Object, context);
			Channel entity = new Channel();
			context.Set<Channel>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Channel());

			var modifiedRecord = context.Set<Channel>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ChannelRepository>> loggerMoc = ChannelRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChannelRepositoryMoc.GetContext();
			var repository = new ChannelRepository(loggerMoc.Object, context);
			Channel entity = new Channel();
			context.Set<Channel>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Channel modifiedRecord = await context.Set<Channel>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>e2cbba80612b5f0df0bd365b0e274997</Hash>
</Codenesium>*/