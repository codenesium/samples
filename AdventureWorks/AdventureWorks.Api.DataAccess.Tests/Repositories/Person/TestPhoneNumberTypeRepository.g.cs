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
	public partial class PhoneNumberTypeRepositoryMoc
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

		public static Mock<ILogger<PhoneNumberTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PhoneNumberTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "Repositories")]
	public partial class PhoneNumberTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);

			PhoneNumberType entity = new PhoneNumberType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PhoneNumberTypeID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);

			var entity = new PhoneNumberType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			await repository.Create(entity);

			var records = await context.Set<PhoneNumberType>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);
			PhoneNumberType entity = new PhoneNumberType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PhoneNumberTypeID);

			await repository.Update(record);

			var records = await context.Set<PhoneNumberType>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);
			PhoneNumberType entity = new PhoneNumberType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<PhoneNumberType>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);
			PhoneNumberType entity = new PhoneNumberType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.PhoneNumberTypeID);

			var records = await context.Set<PhoneNumberType>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>d416b2d6fe01afcb05ae0e7f67b7385f</Hash>
</Codenesium>*/