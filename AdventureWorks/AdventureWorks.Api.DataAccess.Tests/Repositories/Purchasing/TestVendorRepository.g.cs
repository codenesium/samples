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
	public partial class VendorRepositoryMoc
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

			await context.SaveChangesAsync();

			var records = await repository.All();

			records.Should().NotBeEmpty();
			records.Count.Should().Be(1);
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);

			Vendor entity = new Vendor();
			entity.SetProperties("B", true, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
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
			entity.SetProperties("B", true, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			await repository.Create(entity);

			var records = await context.Set<Vendor>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);
			Vendor entity = new Vendor();
			entity.SetProperties("B", true, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			context.Set<Vendor>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.BusinessEntityID);

			await repository.Update(record);

			var records = await context.Set<Vendor>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);
			Vendor entity = new Vendor();
			entity.SetProperties("B", true, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			context.Set<Vendor>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(entity);

			var records = await context.Set<Vendor>().Where(x => true).ToListAsync();

			records.Count.Should().Be(2);
		}

		[Fact]
		public async void DeleteFound()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);
			Vendor entity = new Vendor();
			entity.SetProperties("B", true, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			context.Set<Vendor>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.BusinessEntityID);

			var records = await context.Set<Vendor>().Where(x => true).ToListAsync();

			records.Count.Should().Be(1);
		}

		[Fact]
		public void DeleteNotFound()
		{
			Mock<ILogger<VendorRepository>> loggerMoc = VendorRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VendorRepositoryMoc.GetContext();
			var repository = new VendorRepository(loggerMoc.Object, context);

			Func<Task> delete = async () =>
			{
				await repository.Delete(default(int));
			};

			delete.Should().NotThrow();
		}
	}
}

/*<Codenesium>
    <Hash>a374468a56f1dfb850a6200f19c30751</Hash>
</Codenesium>*/