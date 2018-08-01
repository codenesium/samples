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
	public partial class StateProvinceRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<StateProvinceRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<StateProvinceRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "StateProvince")]
	[Trait("Area", "Repositories")]
	public partial class StateProvinceRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<StateProvinceRepository>> loggerMoc = StateProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StateProvinceRepositoryMoc.GetContext();
			var repository = new StateProvinceRepository(loggerMoc.Object, context);

			StateProvince entity = new StateProvince();
			context.Set<StateProvince>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<StateProvinceRepository>> loggerMoc = StateProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StateProvinceRepositoryMoc.GetContext();
			var repository = new StateProvinceRepository(loggerMoc.Object, context);

			StateProvince entity = new StateProvince();
			context.Set<StateProvince>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.StateProvinceID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<StateProvinceRepository>> loggerMoc = StateProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StateProvinceRepositoryMoc.GetContext();
			var repository = new StateProvinceRepository(loggerMoc.Object, context);

			var entity = new StateProvince();
			await repository.Create(entity);

			var record = await context.Set<StateProvince>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<StateProvinceRepository>> loggerMoc = StateProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StateProvinceRepositoryMoc.GetContext();
			var repository = new StateProvinceRepository(loggerMoc.Object, context);
			StateProvince entity = new StateProvince();
			context.Set<StateProvince>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.StateProvinceID);

			await repository.Update(record);

			var modifiedRecord = context.Set<StateProvince>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<StateProvinceRepository>> loggerMoc = StateProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StateProvinceRepositoryMoc.GetContext();
			var repository = new StateProvinceRepository(loggerMoc.Object, context);
			StateProvince entity = new StateProvince();
			context.Set<StateProvince>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new StateProvince());

			var modifiedRecord = context.Set<StateProvince>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<StateProvinceRepository>> loggerMoc = StateProvinceRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = StateProvinceRepositoryMoc.GetContext();
			var repository = new StateProvinceRepository(loggerMoc.Object, context);
			StateProvince entity = new StateProvince();
			context.Set<StateProvince>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.StateProvinceID);

			StateProvince modifiedRecord = await context.Set<StateProvince>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f101851d51be1712be2183df97d38261</Hash>
</Codenesium>*/