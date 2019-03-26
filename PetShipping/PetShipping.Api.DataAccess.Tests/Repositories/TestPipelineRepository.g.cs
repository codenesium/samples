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
	public partial class PipelineRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			string connectionString = connectionStringBuilder.ToString();
			SqliteConnection connection = new SqliteConnection(connectionString);
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			options.UseSqlite(connection);
			var context = new ApplicationDbContext(options.Options, null);
			context.Database.OpenConnection();
			context.Database.EnsureCreated();
			IntegrationTestMigration migrator = new IntegrationTestMigration(context);
			migrator.Migrate().Wait();
			return context;
		}

		public static Mock<ILogger<PipelineRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PipelineRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Pipeline")]
	[Trait("Area", "Repositories")]
	public partial class PipelineRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
			var repository = new PipelineRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
			var repository = new PipelineRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
			var repository = new PipelineRepository(loggerMoc.Object, context);

			Pipeline entity = new Pipeline();
			entity.SetProperties(default(int), 1, 2);
			context.Set<Pipeline>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
			var repository = new PipelineRepository(loggerMoc.Object, context);

			var entity = new Pipeline();
			entity.SetProperties(default(int), 1, 2);
			await repository.Create(entity);

			var records = await context.Set<Pipeline>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
			var repository = new PipelineRepository(loggerMoc.Object, context);
			Pipeline entity = new Pipeline();
			entity.SetProperties(default(int), 1, 2);
			context.Set<Pipeline>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<Pipeline>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
			var repository = new PipelineRepository(loggerMoc.Object, context);
			Pipeline entity = new Pipeline();
			entity.SetProperties(default(int), 1, 2);
			context.Set<Pipeline>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<Pipeline>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
			var repository = new PipelineRepository(loggerMoc.Object, context);
			Pipeline entity = new Pipeline();
			entity.SetProperties(default(int), 1, 2);
			context.Set<Pipeline>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<Pipeline>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PipelineRepository>> loggerMoc = PipelineRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineRepositoryMoc.GetContext();
			var repository = new PipelineRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>5ea6864ef4c8ae21406ca46efdec5da3</Hash>
</Codenesium>*/