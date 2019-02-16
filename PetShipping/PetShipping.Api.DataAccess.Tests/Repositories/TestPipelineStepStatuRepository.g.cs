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
	public partial class PipelineStepStatuRepositoryMoc
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

		public static Mock<ILogger<PipelineStepStatuRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PipelineStepStatuRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "Repositories")]
	public partial class PipelineStepStatuRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);

			PipelineStepStatu entity = new PipelineStepStatu();
			entity.SetProperties(default(int), "B");
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);

			var entity = new PipelineStepStatu();
			entity.SetProperties(default(int), "B");
			await repository.Create(entity);

			var records = await context.Set<PipelineStepStatu>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);
			PipelineStepStatu entity = new PipelineStepStatu();
			entity.SetProperties(default(int), "B");
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var records = await context.Set<PipelineStepStatu>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);
			PipelineStepStatu entity = new PipelineStepStatu();
			entity.SetProperties(default(int), "B");
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<PipelineStepStatu>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);
			PipelineStepStatu entity = new PipelineStepStatu();
			entity.SetProperties(default(int), "B");
			context.Set<PipelineStepStatu>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			var records = await context.Set<PipelineStepStatu>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PipelineStepStatuRepository>> loggerMoc = PipelineStepStatuRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PipelineStepStatuRepositoryMoc.GetContext();
			var repository = new PipelineStepStatuRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>93500e96bd4123720b6f3d3aacb6b945</Hash>
</Codenesium>*/