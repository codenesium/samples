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

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class JobCandidateRepositoryMoc
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

		public static Mock<ILogger<JobCandidateRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<JobCandidateRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "Repositories")]
	public partial class JobCandidateRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
			var repository = new JobCandidateRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
			var repository = new JobCandidateRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, 1.ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
			var repository = new JobCandidateRepository(loggerMoc.Object, context);

			JobCandidate entity = new JobCandidate();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<JobCandidate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.JobCandidateID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
			var repository = new JobCandidateRepository(loggerMoc.Object, context);

			var entity = new JobCandidate();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<JobCandidate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
			var repository = new JobCandidateRepository(loggerMoc.Object, context);
			JobCandidate entity = new JobCandidate();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<JobCandidate>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.JobCandidateID);

			await repository.Update(record);

			var records = await context.Set<JobCandidate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
			var repository = new JobCandidateRepository(loggerMoc.Object, context);
			JobCandidate entity = new JobCandidate();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<JobCandidate>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<JobCandidate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
			var repository = new JobCandidateRepository(loggerMoc.Object, context);
			JobCandidate entity = new JobCandidate();
			entity.SetProperties(default(int), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<JobCandidate>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.JobCandidateID);

			var records = await context.Set<JobCandidate>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<JobCandidateRepository>> loggerMoc = JobCandidateRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = JobCandidateRepositoryMoc.GetContext();
			var repository = new JobCandidateRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>6dcb0c9853d9ff99e8b7cd2d844d4d1b</Hash>
</Codenesium>*/