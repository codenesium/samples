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
	public partial class ProxyRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ProxyRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ProxyRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Proxy")]
	[Trait("Area", "Repositories")]
	public partial class ProxyRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ProxyRepository>> loggerMoc = ProxyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProxyRepositoryMoc.GetContext();
			var repository = new ProxyRepository(loggerMoc.Object, context);

			Proxy entity = new Proxy();
			context.Set<Proxy>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ProxyRepository>> loggerMoc = ProxyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProxyRepositoryMoc.GetContext();
			var repository = new ProxyRepository(loggerMoc.Object, context);

			Proxy entity = new Proxy();
			context.Set<Proxy>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ProxyRepository>> loggerMoc = ProxyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProxyRepositoryMoc.GetContext();
			var repository = new ProxyRepository(loggerMoc.Object, context);

			var entity = new Proxy();
			await repository.Create(entity);

			var record = await context.Set<Proxy>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ProxyRepository>> loggerMoc = ProxyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProxyRepositoryMoc.GetContext();
			var repository = new ProxyRepository(loggerMoc.Object, context);
			Proxy entity = new Proxy();
			context.Set<Proxy>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Proxy>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ProxyRepository>> loggerMoc = ProxyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProxyRepositoryMoc.GetContext();
			var repository = new ProxyRepository(loggerMoc.Object, context);
			Proxy entity = new Proxy();
			context.Set<Proxy>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Proxy());

			var modifiedRecord = context.Set<Proxy>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ProxyRepository>> loggerMoc = ProxyRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ProxyRepositoryMoc.GetContext();
			var repository = new ProxyRepository(loggerMoc.Object, context);
			Proxy entity = new Proxy();
			context.Set<Proxy>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Proxy modifiedRecord = await context.Set<Proxy>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>06de2363d8b06be94ff4c795d76ce60d</Hash>
</Codenesium>*/