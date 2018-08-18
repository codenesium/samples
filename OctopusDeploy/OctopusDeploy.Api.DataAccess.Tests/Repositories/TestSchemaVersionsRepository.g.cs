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
	public partial class SchemaVersionsRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SchemaVersionsRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SchemaVersionsRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaVersions")]
	[Trait("Area", "Repositories")]
	public partial class SchemaVersionsRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SchemaVersionsRepository>> loggerMoc = SchemaVersionsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaVersionsRepositoryMoc.GetContext();
			var repository = new SchemaVersionsRepository(loggerMoc.Object, context);

			SchemaVersions entity = new SchemaVersions();
			context.Set<SchemaVersions>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SchemaVersionsRepository>> loggerMoc = SchemaVersionsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaVersionsRepositoryMoc.GetContext();
			var repository = new SchemaVersionsRepository(loggerMoc.Object, context);

			SchemaVersions entity = new SchemaVersions();
			context.Set<SchemaVersions>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SchemaVersionsRepository>> loggerMoc = SchemaVersionsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaVersionsRepositoryMoc.GetContext();
			var repository = new SchemaVersionsRepository(loggerMoc.Object, context);

			var entity = new SchemaVersions();
			await repository.Create(entity);

			var record = await context.Set<SchemaVersions>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SchemaVersionsRepository>> loggerMoc = SchemaVersionsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaVersionsRepositoryMoc.GetContext();
			var repository = new SchemaVersionsRepository(loggerMoc.Object, context);
			SchemaVersions entity = new SchemaVersions();
			context.Set<SchemaVersions>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<SchemaVersions>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SchemaVersionsRepository>> loggerMoc = SchemaVersionsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaVersionsRepositoryMoc.GetContext();
			var repository = new SchemaVersionsRepository(loggerMoc.Object, context);
			SchemaVersions entity = new SchemaVersions();
			context.Set<SchemaVersions>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SchemaVersions());

			var modifiedRecord = context.Set<SchemaVersions>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SchemaVersionsRepository>> loggerMoc = SchemaVersionsRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaVersionsRepositoryMoc.GetContext();
			var repository = new SchemaVersionsRepository(loggerMoc.Object, context);
			SchemaVersions entity = new SchemaVersions();
			context.Set<SchemaVersions>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			SchemaVersions modifiedRecord = await context.Set<SchemaVersions>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f4587448870d8f3c363301b579490cab</Hash>
</Codenesium>*/