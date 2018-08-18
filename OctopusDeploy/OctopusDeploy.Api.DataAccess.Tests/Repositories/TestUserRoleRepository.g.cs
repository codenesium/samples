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
	public partial class UserRoleRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<UserRoleRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<UserRoleRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "UserRole")]
	[Trait("Area", "Repositories")]
	public partial class UserRoleRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<UserRoleRepository>> loggerMoc = UserRoleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRoleRepositoryMoc.GetContext();
			var repository = new UserRoleRepository(loggerMoc.Object, context);

			UserRole entity = new UserRole();
			context.Set<UserRole>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<UserRoleRepository>> loggerMoc = UserRoleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRoleRepositoryMoc.GetContext();
			var repository = new UserRoleRepository(loggerMoc.Object, context);

			UserRole entity = new UserRole();
			context.Set<UserRole>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<UserRoleRepository>> loggerMoc = UserRoleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRoleRepositoryMoc.GetContext();
			var repository = new UserRoleRepository(loggerMoc.Object, context);

			var entity = new UserRole();
			await repository.Create(entity);

			var record = await context.Set<UserRole>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<UserRoleRepository>> loggerMoc = UserRoleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRoleRepositoryMoc.GetContext();
			var repository = new UserRoleRepository(loggerMoc.Object, context);
			UserRole entity = new UserRole();
			context.Set<UserRole>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<UserRole>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<UserRoleRepository>> loggerMoc = UserRoleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRoleRepositoryMoc.GetContext();
			var repository = new UserRoleRepository(loggerMoc.Object, context);
			UserRole entity = new UserRole();
			context.Set<UserRole>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new UserRole());

			var modifiedRecord = context.Set<UserRole>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<UserRoleRepository>> loggerMoc = UserRoleRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = UserRoleRepositoryMoc.GetContext();
			var repository = new UserRoleRepository(loggerMoc.Object, context);
			UserRole entity = new UserRole();
			context.Set<UserRole>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			UserRole modifiedRecord = await context.Set<UserRole>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>cd9dcb92940090de899a3c43ca9ae81d</Hash>
</Codenesium>*/