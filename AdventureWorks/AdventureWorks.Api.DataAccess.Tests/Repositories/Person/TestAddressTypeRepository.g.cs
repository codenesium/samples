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
	public partial class AddressTypeRepositoryMoc
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

		public static Mock<ILogger<AddressTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<AddressTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "AddressType")]
	[Trait("Area", "Repositories")]
	public partial class AddressTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
			var repository = new AddressTypeRepository(loggerMoc.Object, context);
			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void AllWithSearch()
		{
			Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
			var repository = new AddressTypeRepository(loggerMoc.Object, context);
			var records = await repository.All(1, 0, DateTime.Parse("1/1/1987 12:00:00 AM").ToString());

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
			var repository = new AddressTypeRepository(loggerMoc.Object, context);

			AddressType entity = new AddressType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<AddressType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.AddressTypeID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
			var repository = new AddressTypeRepository(loggerMoc.Object, context);

			var entity = new AddressType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			await repository.Create(entity);

			var records = await context.Set<AddressType>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
			var repository = new AddressTypeRepository(loggerMoc.Object, context);
			AddressType entity = new AddressType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<AddressType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.AddressTypeID);

			await repository.Update(record);

			var records = await context.Set<AddressType>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
			var repository = new AddressTypeRepository(loggerMoc.Object, context);
			AddressType entity = new AddressType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<AddressType>().Add(entity);
			await context.SaveChangesAsync();

			context.Entry(entity).State = EntityState.Detached;

			await repository.Update(entity);

			var records = await context.Set<AddressType>().ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
			var repository = new AddressTypeRepository(loggerMoc.Object, context);
			AddressType entity = new AddressType();
			entity.SetProperties(default(int), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<AddressType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.AddressTypeID);

			var records = await context.Set<AddressType>().ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<AddressTypeRepository>> loggerMoc = AddressTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = AddressTypeRepositoryMoc.GetContext();
			var repository = new AddressTypeRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>8e85ec979d59335007c36016aba61d71</Hash>
</Codenesium>*/