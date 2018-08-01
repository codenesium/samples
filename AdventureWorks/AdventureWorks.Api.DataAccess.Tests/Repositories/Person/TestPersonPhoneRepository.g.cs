using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class PersonPhoneRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PersonPhoneRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PersonPhoneRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PersonPhone")]
	[Trait("Area", "Repositories")]
	public partial class PersonPhoneRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PersonPhoneRepository>> loggerMoc = PersonPhoneRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PersonPhoneRepositoryMoc.GetContext();
			var repository = new PersonPhoneRepository(loggerMoc.Object, context);

			PersonPhone entity = new PersonPhone();
			context.Set<PersonPhone>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PersonPhoneRepository>> loggerMoc = PersonPhoneRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PersonPhoneRepositoryMoc.GetContext();
			var repository = new PersonPhoneRepository(loggerMoc.Object, context);

			PersonPhone entity = new PersonPhone();
			context.Set<PersonPhone>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PersonPhoneRepository>> loggerMoc = PersonPhoneRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PersonPhoneRepositoryMoc.GetContext();
			var repository = new PersonPhoneRepository(loggerMoc.Object, context);

			var entity = new PersonPhone();
			await repository.Create(entity);

			var record = await context.Set<PersonPhone>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PersonPhoneRepository>> loggerMoc = PersonPhoneRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PersonPhoneRepositoryMoc.GetContext();
			var repository = new PersonPhoneRepository(loggerMoc.Object, context);
			PersonPhone entity = new PersonPhone();
			context.Set<PersonPhone>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<PersonPhone>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PersonPhoneRepository>> loggerMoc = PersonPhoneRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PersonPhoneRepositoryMoc.GetContext();
			var repository = new PersonPhoneRepository(loggerMoc.Object, context);
			PersonPhone entity = new PersonPhone();
			context.Set<PersonPhone>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PersonPhone());

			var modifiedRecord = context.Set<PersonPhone>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PersonPhoneRepository>> loggerMoc = PersonPhoneRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PersonPhoneRepositoryMoc.GetContext();
			var repository = new PersonPhoneRepository(loggerMoc.Object, context);
			PersonPhone entity = new PersonPhone();
			context.Set<PersonPhone>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			PersonPhone modifiedRecord = await context.Set<PersonPhone>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>12fde10444eaae73c4527c15391dfef1</Hash>
</Codenesium>*/