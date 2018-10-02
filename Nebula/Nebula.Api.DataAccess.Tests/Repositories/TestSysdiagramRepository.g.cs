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
	public partial class SysdiagramRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<SysdiagramRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<SysdiagramRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Sysdiagram")]
	[Trait("Area", "Repositories")]
	public partial class SysdiagramRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<SysdiagramRepository>> loggerMoc = SysdiagramRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SysdiagramRepositoryMoc.GetContext();
			var repository = new SysdiagramRepository(loggerMoc.Object, context);

			Sysdiagram entity = new Sysdiagram();
			context.Set<Sysdiagram>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<SysdiagramRepository>> loggerMoc = SysdiagramRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SysdiagramRepositoryMoc.GetContext();
			var repository = new SysdiagramRepository(loggerMoc.Object, context);

			Sysdiagram entity = new Sysdiagram();
			context.Set<Sysdiagram>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.DiagramId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<SysdiagramRepository>> loggerMoc = SysdiagramRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SysdiagramRepositoryMoc.GetContext();
			var repository = new SysdiagramRepository(loggerMoc.Object, context);

			var entity = new Sysdiagram();
			await repository.Create(entity);

			var record = await context.Set<Sysdiagram>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<SysdiagramRepository>> loggerMoc = SysdiagramRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SysdiagramRepositoryMoc.GetContext();
			var repository = new SysdiagramRepository(loggerMoc.Object, context);
			Sysdiagram entity = new Sysdiagram();
			context.Set<Sysdiagram>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.DiagramId);

			await repository.Update(record);

			var modifiedRecord = context.Set<Sysdiagram>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<SysdiagramRepository>> loggerMoc = SysdiagramRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SysdiagramRepositoryMoc.GetContext();
			var repository = new SysdiagramRepository(loggerMoc.Object, context);
			Sysdiagram entity = new Sysdiagram();
			context.Set<Sysdiagram>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Sysdiagram());

			var modifiedRecord = context.Set<Sysdiagram>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<SysdiagramRepository>> loggerMoc = SysdiagramRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = SysdiagramRepositoryMoc.GetContext();
			var repository = new SysdiagramRepository(loggerMoc.Object, context);
			Sysdiagram entity = new Sysdiagram();
			context.Set<Sysdiagram>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.DiagramId);

			Sysdiagram modifiedRecord = await context.Set<Sysdiagram>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>5ad3e252915a236be2f86b6bcc315853</Hash>
</Codenesium>*/