using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class UserRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<UserRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<UserRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "Repositories")]
	public partial class UserRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);

			User entity = new User();
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);

			User entity = new User();
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);

			var entity = new User();
			await repository.Create(entity);

			var record = await context.Set<User>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);
			User entity = new User();
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<User>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);
			User entity = new User();
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new User());

			var modifiedRecord = context.Set<User>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<UserRepository>> loggerMoc = UserRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRepositoryMoc.GetContext();
			var repository = new UserRepository(loggerMoc.Object, context);
			User entity = new User();
			context.Set<User>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			User modifiedRecord = await context.Set<User>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>48a566a233a73a2e4b15a88953270df6</Hash>
</Codenesium>*/