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

namespace TestsNS.Api.DataAccess
{
	public partial class VPersonRepositoryMoc
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

		public static Mock<ILogger<VPersonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VPersonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "Repositories")]
	public partial class VPersonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, "A".ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);

			VPerson entity = new VPerson();
			entity.SetProperties(default(int), "B");
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PersonId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);

			var entity = new VPerson();
			entity.SetProperties(default(int), "B");
			await repository.Create(entity);

			var records = await context.Set<VPerson>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);
			VPerson entity = new VPerson();
			entity.SetProperties(default(int), "B");
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PersonId);

			await repository.Update(record);

			var records = await context.Set<VPerson>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);
			VPerson entity = new VPerson();
			entity.SetProperties(default(int), "B");
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<VPerson>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);
			VPerson entity = new VPerson();
			entity.SetProperties(default(int), "B");
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.PersonId);

			var records = await context.Set<VPerson>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>50b7e6ce698e19f6dbfb1be4094b163b</Hash>
</Codenesium>*/