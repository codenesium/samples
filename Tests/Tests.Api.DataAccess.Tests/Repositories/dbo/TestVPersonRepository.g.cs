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
	public partial class VPersonRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VPersonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VPersonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "Repositories")]
	public partial class VPersonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);

			VPerson entity = new VPerson();
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);

			VPerson entity = new VPerson();
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PersonId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);

			var entity = new VPerson();
			await repository.Create(entity);

			var record = await context.Set<VPerson>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);
			VPerson entity = new VPerson();
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PersonId);

			await repository.Update(record);

			var modifiedRecord = context.Set<VPerson>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);
			VPerson entity = new VPerson();
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new VPerson());

			var modifiedRecord = context.Set<VPerson>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);
			VPerson entity = new VPerson();
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.PersonId);

			VPerson modifiedRecord = await context.Set<VPerson>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>c6f7799579333aaa93ffd0e49a61cdc6</Hash>
</Codenesium>*/