using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial class AdminRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<AdminRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AdminRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "Repositories")]
	public partial class AdminRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);

			Admin entity = new Admin();
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);

			Admin entity = new Admin();
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);

			var entity = new Admin();
			await repository.Create(entity);

			var record = await context.Set<Admin>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);
			Admin entity = new Admin();
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Admin>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);
			Admin entity = new Admin();
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Admin());

			var modifiedRecord = context.Set<Admin>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);
			Admin entity = new Admin();
			context.Set<Admin>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Admin modifiedRecord = await context.Set<Admin>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AdminRepository>> loggerMoc = AdminRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AdminRepositoryMoc.GetContext();
			var repository = new AdminRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>6503b6d65aab6c55cf9ff1f8b4c3a16a</Hash>
</Codenesium>*/