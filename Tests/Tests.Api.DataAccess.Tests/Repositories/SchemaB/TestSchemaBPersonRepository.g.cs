using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TestsNS.Api.DataAccess
{
	public partial class SchemaBPersonRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SchemaBPersonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SchemaBPersonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "Repositories")]
	public partial class SchemaBPersonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SchemaBPersonRepository>> loggerMoc = SchemaBPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaBPersonRepositoryMoc.GetContext();
			var repository = new SchemaBPersonRepository(loggerMoc.Object, context);

			SchemaBPerson entity = new SchemaBPerson();
			context.Set<SchemaBPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SchemaBPersonRepository>> loggerMoc = SchemaBPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaBPersonRepositoryMoc.GetContext();
			var repository = new SchemaBPersonRepository(loggerMoc.Object, context);

			SchemaBPerson entity = new SchemaBPerson();
			context.Set<SchemaBPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SchemaBPersonRepository>> loggerMoc = SchemaBPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaBPersonRepositoryMoc.GetContext();
			var repository = new SchemaBPersonRepository(loggerMoc.Object, context);

			var entity = new SchemaBPerson();
			await repository.Create(entity);

			var record = await context.Set<SchemaBPerson>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SchemaBPersonRepository>> loggerMoc = SchemaBPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaBPersonRepositoryMoc.GetContext();
			var repository = new SchemaBPersonRepository(loggerMoc.Object, context);
			SchemaBPerson entity = new SchemaBPerson();
			context.Set<SchemaBPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<SchemaBPerson>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SchemaBPersonRepository>> loggerMoc = SchemaBPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaBPersonRepositoryMoc.GetContext();
			var repository = new SchemaBPersonRepository(loggerMoc.Object, context);
			SchemaBPerson entity = new SchemaBPerson();
			context.Set<SchemaBPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new SchemaBPerson());

			var modifiedRecord = context.Set<SchemaBPerson>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SchemaBPersonRepository>> loggerMoc = SchemaBPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SchemaBPersonRepositoryMoc.GetContext();
			var repository = new SchemaBPersonRepository(loggerMoc.Object, context);
			SchemaBPerson entity = new SchemaBPerson();
			context.Set<SchemaBPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			SchemaBPerson modifiedRecord = await context.Set<SchemaBPerson>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>ef7b3cab2ab4211e7b311134d29f9005</Hash>
</Codenesium>*/