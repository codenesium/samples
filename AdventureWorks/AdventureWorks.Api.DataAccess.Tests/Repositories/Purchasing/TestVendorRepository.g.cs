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
	public partial class VendorRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VendorRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VendorRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Vendor")]
	[Trait("Area", "Repositories")]
	public partial class VendorRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);

			Vendor entity = new Vendor();
			context.Set<Vendor>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);

			Vendor entity = new Vendor();
			context.Set<Vendor>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);

			var entity = new Vendor();
			await repository.Create(entity);

			var record = await context.Set<Vendor>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);
			Vendor entity = new Vendor();
			context.Set<Vendor>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Vendor>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);
			Vendor entity = new Vendor();
			context.Set<Vendor>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Vendor());

			var modifiedRecord = context.Set<Vendor>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);
			Vendor entity = new Vendor();
			context.Set<Vendor>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			Vendor modifiedRecord = await context.Set<Vendor>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>0a5b20edad5183a139ef527f47b0fb16</Hash>
</Codenesium>*/