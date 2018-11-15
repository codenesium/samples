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
	public partial class ErrorLogRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ErrorLogRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ErrorLogRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "Repositories")]
	public partial class ErrorLogRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);

			ErrorLog entity = new ErrorLog();
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);

			ErrorLog entity = new ErrorLog();
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ErrorLogID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);

			var entity = new ErrorLog();
			await repository.Create(entity);

			var record = await context.Set<ErrorLog>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);
			ErrorLog entity = new ErrorLog();
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.ErrorLogID);

			await repository.Update(record);

			var modifiedRecord = context.Set<ErrorLog>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);
			ErrorLog entity = new ErrorLog();
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ErrorLog());

			var modifiedRecord = context.Set<ErrorLog>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);
			ErrorLog entity = new ErrorLog();
			context.Set<ErrorLog>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.ErrorLogID);

			ErrorLog modifiedRecord = await context.Set<ErrorLog>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<ErrorLogRepository>> loggerMoc = ErrorLogRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ErrorLogRepositoryMoc.GetContext();
			var repository = new ErrorLogRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>9c7a00753a4a15b9978aa814c50c7547</Hash>
</Codenesium>*/