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
	public partial class BusinessEntityRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<BusinessEntityRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<BusinessEntityRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "BusinessEntity")]
	[Trait("Area", "Repositories")]
	public partial class BusinessEntityRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);

			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);

			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);

			var entity = new BusinessEntity();
			await repository.Create(entity);

			var record = await context.Set<BusinessEntity>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);
			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<BusinessEntity>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);
			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new BusinessEntity());

			var modifiedRecord = context.Set<BusinessEntity>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);
			BusinessEntity entity = new BusinessEntity();
			context.Set<BusinessEntity>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			BusinessEntity modifiedRecord = await context.Set<BusinessEntity>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<BusinessEntityRepository>> loggerMoc = BusinessEntityRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = BusinessEntityRepositoryMoc.GetContext();
			var repository = new BusinessEntityRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>1fe1956e19ca54b74867a31eb9700cef</Hash>
</Codenesium>*/