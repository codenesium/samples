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
	public partial class AddressRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<AddressRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AddressRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Address")]
	[Trait("Area", "Repositories")]
	public partial class AddressRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AddressRepository>> loggerMoc = AddressRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressRepositoryMoc.GetContext();
			var repository = new AddressRepository(loggerMoc.Object, context);

			Address entity = new Address();
			context.Set<Address>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AddressRepository>> loggerMoc = AddressRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressRepositoryMoc.GetContext();
			var repository = new AddressRepository(loggerMoc.Object, context);

			Address entity = new Address();
			context.Set<Address>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.AddressID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AddressRepository>> loggerMoc = AddressRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressRepositoryMoc.GetContext();
			var repository = new AddressRepository(loggerMoc.Object, context);

			var entity = new Address();
			await repository.Create(entity);

			var record = await context.Set<Address>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AddressRepository>> loggerMoc = AddressRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressRepositoryMoc.GetContext();
			var repository = new AddressRepository(loggerMoc.Object, context);
			Address entity = new Address();
			context.Set<Address>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.AddressID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Address>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AddressRepository>> loggerMoc = AddressRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressRepositoryMoc.GetContext();
			var repository = new AddressRepository(loggerMoc.Object, context);
			Address entity = new Address();
			context.Set<Address>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Address());

			var modifiedRecord = context.Set<Address>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<AddressRepository>> loggerMoc = AddressRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressRepositoryMoc.GetContext();
			var repository = new AddressRepository(loggerMoc.Object, context);
			Address entity = new Address();
			context.Set<Address>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.AddressID);

			Address modifiedRecord = await context.Set<Address>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AddressRepository>> loggerMoc = AddressRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressRepositoryMoc.GetContext();
			var repository = new AddressRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>2a74c1665ef7fea201e06abc009de982</Hash>
</Codenesium>*/