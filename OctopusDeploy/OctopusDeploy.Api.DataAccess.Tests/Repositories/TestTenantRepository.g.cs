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
	public partial class TenantRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<TenantRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<TenantRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "Repositories")]
	public partial class TenantRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<TenantRepository>> loggerMoc = TenantRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TenantRepositoryMoc.GetContext();
			var repository = new TenantRepository(loggerMoc.Object, context);

			Tenant entity = new Tenant();
			context.Set<Tenant>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<TenantRepository>> loggerMoc = TenantRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TenantRepositoryMoc.GetContext();
			var repository = new TenantRepository(loggerMoc.Object, context);

			Tenant entity = new Tenant();
			context.Set<Tenant>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<TenantRepository>> loggerMoc = TenantRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TenantRepositoryMoc.GetContext();
			var repository = new TenantRepository(loggerMoc.Object, context);

			var entity = new Tenant();
			await repository.Create(entity);

			var record = await context.Set<Tenant>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<TenantRepository>> loggerMoc = TenantRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TenantRepositoryMoc.GetContext();
			var repository = new TenantRepository(loggerMoc.Object, context);
			Tenant entity = new Tenant();
			context.Set<Tenant>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Tenant>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<TenantRepository>> loggerMoc = TenantRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TenantRepositoryMoc.GetContext();
			var repository = new TenantRepository(loggerMoc.Object, context);
			Tenant entity = new Tenant();
			context.Set<Tenant>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Tenant());

			var modifiedRecord = context.Set<Tenant>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<TenantRepository>> loggerMoc = TenantRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = TenantRepositoryMoc.GetContext();
			var repository = new TenantRepository(loggerMoc.Object, context);
			Tenant entity = new Tenant();
			context.Set<Tenant>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Tenant modifiedRecord = await context.Set<Tenant>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>2f1cd0cb8863d8a0331d670916af8fae</Hash>
</Codenesium>*/