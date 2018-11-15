using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestsNS.Api.DataAccess
{
	public partial class SchemaAPersonRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SchemaAPersonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SchemaAPersonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "Repositories")]
	public partial class SchemaAPersonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SchemaAPersonRepository>> loggerMoc = SchemaAPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaAPersonRepositoryMoc.GetContext();
			var repository = new SchemaAPersonRepository(loggerMoc.Object, context);

			SchemaAPerson entity = new SchemaAPerson();
			context.Set<SchemaAPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SchemaAPersonRepository>> loggerMoc = SchemaAPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaAPersonRepositoryMoc.GetContext();
			var repository = new SchemaAPersonRepository(loggerMoc.Object, context);

			SchemaAPerson entity = new SchemaAPerson();
			context.Set<SchemaAPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SchemaAPersonRepository>> loggerMoc = SchemaAPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaAPersonRepositoryMoc.GetContext();
			var repository = new SchemaAPersonRepository(loggerMoc.Object, context);

			var entity = new SchemaAPerson();
			await repository.Create(entity);

			var record = await context.Set<SchemaAPerson>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SchemaAPersonRepository>> loggerMoc = SchemaAPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaAPersonRepositoryMoc.GetContext();
			var repository = new SchemaAPersonRepository(loggerMoc.Object, context);
			SchemaAPerson entity = new SchemaAPerson();
			context.Set<SchemaAPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<SchemaAPerson>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SchemaAPersonRepository>> loggerMoc = SchemaAPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaAPersonRepositoryMoc.GetContext();
			var repository = new SchemaAPersonRepository(loggerMoc.Object, context);
			SchemaAPerson entity = new SchemaAPerson();
			context.Set<SchemaAPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SchemaAPerson());

			var modifiedRecord = context.Set<SchemaAPerson>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<SchemaAPersonRepository>> loggerMoc = SchemaAPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaAPersonRepositoryMoc.GetContext();
			var repository = new SchemaAPersonRepository(loggerMoc.Object, context);
			SchemaAPerson entity = new SchemaAPerson();
			context.Set<SchemaAPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			SchemaAPerson modifiedRecord = await context.Set<SchemaAPerson>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<SchemaAPersonRepository>> loggerMoc = SchemaAPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaAPersonRepositoryMoc.GetContext();
			var repository = new SchemaAPersonRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>0a64f401d6cb86c60dfd85d1ddcaeb26</Hash>
</Codenesium>*/