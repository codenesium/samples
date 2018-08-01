using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace NebulaNS.Api.DataAccess
{
	public partial class OrganizationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<OrganizationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<OrganizationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Organization")]
	[Trait("Area", "Repositories")]
	public partial class OrganizationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<OrganizationRepository>> loggerMoc = OrganizationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OrganizationRepositoryMoc.GetContext();
			var repository = new OrganizationRepository(loggerMoc.Object, context);

			Organization entity = new Organization();
			context.Set<Organization>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<OrganizationRepository>> loggerMoc = OrganizationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OrganizationRepositoryMoc.GetContext();
			var repository = new OrganizationRepository(loggerMoc.Object, context);

			Organization entity = new Organization();
			context.Set<Organization>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<OrganizationRepository>> loggerMoc = OrganizationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OrganizationRepositoryMoc.GetContext();
			var repository = new OrganizationRepository(loggerMoc.Object, context);

			var entity = new Organization();
			await repository.Create(entity);

			var record = await context.Set<Organization>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<OrganizationRepository>> loggerMoc = OrganizationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OrganizationRepositoryMoc.GetContext();
			var repository = new OrganizationRepository(loggerMoc.Object, context);
			Organization entity = new Organization();
			context.Set<Organization>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Organization>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<OrganizationRepository>> loggerMoc = OrganizationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OrganizationRepositoryMoc.GetContext();
			var repository = new OrganizationRepository(loggerMoc.Object, context);
			Organization entity = new Organization();
			context.Set<Organization>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Organization());

			var modifiedRecord = context.Set<Organization>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<OrganizationRepository>> loggerMoc = OrganizationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = OrganizationRepositoryMoc.GetContext();
			var repository = new OrganizationRepository(loggerMoc.Object, context);
			Organization entity = new Organization();
			context.Set<Organization>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Organization modifiedRecord = await context.Set<Organization>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>b3c87102c50a97af17adfeefd7d2c550</Hash>
</Codenesium>*/