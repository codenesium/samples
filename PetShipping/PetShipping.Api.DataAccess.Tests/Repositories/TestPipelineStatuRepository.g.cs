using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineStatuRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
		}

		public static Mock<ILogger<PipelineStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PipelineStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "Repositories")]
	public partial class PipelineStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);

			PipelineStatu entity = new PipelineStatu();
			entity.SetProperties(2, "B");
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);

			var entity = new PipelineStatu();
			entity.SetProperties(2, "B");
			await repository.Create(entity);

			var records = await context.Set<PipelineStatu>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);
			PipelineStatu entity = new PipelineStatu();
			entity.SetProperties(2, "B");
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<PipelineStatu>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);
			PipelineStatu entity = new PipelineStatu();
			entity.SetProperties(2, "B");
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<PipelineStatu>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);
			PipelineStatu entity = new PipelineStatu();
			entity.SetProperties(2, "B");
			context.Set<PipelineStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<PipelineStatu>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PipelineStatuRepository>> loggerMoc = PipelineStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStatuRepositoryMoc.GetContext();
			var repository = new PipelineStatuRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>1982ab22cfdd0fb32c248088200684ee</Hash>
</Codenesium>*/