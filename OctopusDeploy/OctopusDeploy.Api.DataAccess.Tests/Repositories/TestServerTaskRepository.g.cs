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
	public partial class ServerTaskRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ServerTaskRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ServerTaskRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ServerTask")]
	[Trait("Area", "Repositories")]
	public partial class ServerTaskRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ServerTaskRepository>> loggerMoc = ServerTaskRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ServerTaskRepositoryMoc.GetContext();
			var repository = new ServerTaskRepository(loggerMoc.Object, context);

			ServerTask entity = new ServerTask();
			context.Set<ServerTask>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ServerTaskRepository>> loggerMoc = ServerTaskRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ServerTaskRepositoryMoc.GetContext();
			var repository = new ServerTaskRepository(loggerMoc.Object, context);

			ServerTask entity = new ServerTask();
			context.Set<ServerTask>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ServerTaskRepository>> loggerMoc = ServerTaskRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ServerTaskRepositoryMoc.GetContext();
			var repository = new ServerTaskRepository(loggerMoc.Object, context);

			var entity = new ServerTask();
			await repository.Create(entity);

			var record = await context.Set<ServerTask>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ServerTaskRepository>> loggerMoc = ServerTaskRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ServerTaskRepositoryMoc.GetContext();
			var repository = new ServerTaskRepository(loggerMoc.Object, context);
			ServerTask entity = new ServerTask();
			context.Set<ServerTask>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ServerTask>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ServerTaskRepository>> loggerMoc = ServerTaskRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ServerTaskRepositoryMoc.GetContext();
			var repository = new ServerTaskRepository(loggerMoc.Object, context);
			ServerTask entity = new ServerTask();
			context.Set<ServerTask>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ServerTask());

			var modifiedRecord = context.Set<ServerTask>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ServerTaskRepository>> loggerMoc = ServerTaskRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ServerTaskRepositoryMoc.GetContext();
			var repository = new ServerTaskRepository(loggerMoc.Object, context);
			ServerTask entity = new ServerTask();
			context.Set<ServerTask>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ServerTask modifiedRecord = await context.Set<ServerTask>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>06537a16711982315e1f131f64e0aa9f</Hash>
</Codenesium>*/