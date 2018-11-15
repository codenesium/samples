using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class PasswordRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PasswordRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PasswordRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Password")]
	[Trait("Area", "Repositories")]
	public partial class PasswordRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);

			Password entity = new Password();
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);

			Password entity = new Password();
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);

			var entity = new Password();
			await repository.Create(entity);

			var record = await context.Set<Password>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);
			Password entity = new Password();
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Password>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);
			Password entity = new Password();
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Password());

			var modifiedRecord = context.Set<Password>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);
			Password entity = new Password();
			context.Set<Password>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			Password modifiedRecord = await context.Set<Password>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PasswordRepository>> loggerMoc = PasswordRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PasswordRepositoryMoc.GetContext();
			var repository = new PasswordRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>0531a2d6f5e327830d656c64169cadf1</Hash>
</Codenesium>*/