using Codenesium.Foundation.CommonMVC;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xunit;
using TicketingCRMNS.Api.DataAccess;

namespace Codenesium.Foundation.CommonMVC.Tests
{
    [Trait("Type", "Unit")]
    [Trait("Table", "Lib")]
    public partial class IncludesTests
    {
        [Fact]
        public void TransactionCoordinator_Begin_Transaction()
        {
            var context = TestContext.Factory();
            var coordinator = new EntityFrameworkTransactionCoordinator(context);

            context.Database.CurrentTransaction.Should().BeNull();
            coordinator.BeginTransaction();
            context.Database.CurrentTransaction.Should().NotBeNull();
        }

        [Fact]
        public void TransactionCoordinator_Commit_Transaction()
        {
            var context = TestContext.Factory();
            var coordinator = new EntityFrameworkTransactionCoordinator(context);

            coordinator.BeginTransaction();
            context.Entities.Add(new TestEntity());
            context.SaveChanges();
            coordinator.CommitTransaction();

            context.Entities.FirstOrDefault(x => x.Id == 1).Should().NotBeNull();
            context.Database.CurrentTransaction.Should().BeNull();
        }

        [Fact]
        public void TransactionCoordinator_Rollback_Transaction()
        {
            var context = TestContext.Factory();
            var coordinator = new EntityFrameworkTransactionCoordinator(context);

            coordinator.BeginTransaction();
            context.Entities.Add(new TestEntity());
            context.SaveChanges();
            coordinator.RollbackTransaction();

            context.Entities.FirstOrDefault(x => x.Id == 1).Should().BeNull();
            context.Database.CurrentTransaction.Should().BeNull();
        }

        [Fact]
        public void TransactionCoordinator_Enable_Change_Tracking()
        {
            var context = TestContext.Factory();
            var coordinator = new EntityFrameworkTransactionCoordinator(context);

            context.ChangeTracker.AutoDetectChangesEnabled = false;
            coordinator.EnableChangeTracking();

            context.ChangeTracker.AutoDetectChangesEnabled.Should().BeTrue();
        }

        [Fact]
        public void TransactionCoordinator_Disable_Change_Tracking()
        {
            var context = TestContext.Factory();
            var coordinator = new EntityFrameworkTransactionCoordinator(context);

            context.ChangeTracker.AutoDetectChangesEnabled = true;
            coordinator.DisableChangeTracking();

            context.ChangeTracker.AutoDetectChangesEnabled.Should().BeFalse();
        }
    }
	    
	public class TestEntity
    {
        [Key]
        public int Id { get; set; }
    }

    public class TestContext : ApplicationDbContext
    {
        public TestContext(DbContextOptions options)
                        : base(options)
        {
        }

        public DbSet<TestEntity> Entities { get; set; }

        public static TestContext Factory()
        {
            SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            string connectionString = connectionStringBuilder.ToString();
            SqliteConnection connection = new SqliteConnection(connectionString);

            var options = new DbContextOptionsBuilder<DbContext>()
                     .UseSqlite(connection);

            var context = new TestContext(options.Options);

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            return context;
        }
    }
}