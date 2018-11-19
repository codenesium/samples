using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Update;
using StackOverflowNS.Api.DataAccess;

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

		[Fact]
		public void NullModelValidaterAttribute_Null()
		{
			NullModelValidaterAttribute attribute = new NullModelValidaterAttribute();

			var modelState = new ModelStateDictionary();
			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = null;

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				new Mock<Controller>().Object
			);

		    attribute.OnActionExecuting(actionExecutingContext);
			actionExecutingContext.Result.Should().BeOfType<BadRequestObjectResult>();
		}

		[Fact]
		public void NullModelValidaterAttribute_NotNull()
		{
			NullModelValidaterAttribute attribute = new NullModelValidaterAttribute();

			var modelState = new ModelStateDictionary();

			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = "not null";

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				new Mock<Controller>().Object
			);

			attribute.OnActionExecuting(actionExecutingContext);
			actionExecutingContext.Result.Should().BeNull();
		}

		[Fact]
		public void NullModelValidaterAttribute_NotNull_ModelErrors()
		{
			NullModelValidaterAttribute attribute = new NullModelValidaterAttribute();

			var modelState = new ModelStateDictionary();
			modelState.AddModelError("error", "value");

			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = "not null";

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				new Mock<Controller>().Object
			);

			attribute.OnActionExecuting(actionExecutingContext);
			actionExecutingContext.Result.Should().BeOfType<BadRequestObjectResult>();
			(actionExecutingContext.Result as BadRequestObjectResult).Value.Should().BeOfType<List<Exception>>();
		}

		[Fact]
		public void ReadOnlyFilter_Applied()
		{
			ReadOnlyAttribute attribute = new ReadOnlyAttribute();

			var modelState = new ModelStateDictionary();

			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = "not null";

			var transactionCoordinatorMock = new Mock<ITransactionCoordinator>();
			transactionCoordinatorMock.Setup(x => x.DisableChangeTracking());

			var dbcontextMock = new Mock<DbContext>();

			ApiHealthController controller = new ApiHealthController(new Mock<ApiSettings>().Object, new Mock<ILogger<ApiHealthController>>().Object, transactionCoordinatorMock.Object, dbcontextMock.Object);

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				controller
			);

			attribute.OnActionExecuting(actionExecutingContext);
			actionExecutingContext.Result.Should().BeNull();
			transactionCoordinatorMock.Verify(x => x.DisableChangeTracking());
		}

		[Fact]
		public void UnitOfWorkFilter_NoErrors()
		{
			UnitOfWorkAttribute attribute = new UnitOfWorkAttribute();

			var modelState = new ModelStateDictionary();

			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = "not null";

			var transactionCoordinatorMock = new Mock<ITransactionCoordinator>();

			var dbcontextMock = new Mock<DbContext>();

			ApiHealthController controller = new ApiHealthController(new Mock<ApiSettings>().Object, new Mock<ILogger<ApiHealthController>>().Object, transactionCoordinatorMock.Object, dbcontextMock.Object);

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				controller
			);

			var actionExecutedContext = new ActionExecutedContext(
				actionContext,
				new List<IFilterMetadata>(),
				controller
			);

			attribute.OnActionExecuting(actionExecutingContext);
			transactionCoordinatorMock.Verify(x => x.BeginTransaction());
			attribute.OnActionExecuted(actionExecutedContext);
			transactionCoordinatorMock.Verify(x => x.CommitTransaction());
		}

		[Fact]
		public void UnitOfWorkFilter_DbConcurrencyException()
		{
			UnitOfWorkAttribute attribute = new UnitOfWorkAttribute();

			var modelState = new ModelStateDictionary();

			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = "not null";

			var transactionCoordinatorMock = new Mock<ITransactionCoordinator>();
			var updateEntry = new Mock<IUpdateEntry>();
			transactionCoordinatorMock.Setup(x => x.CommitTransaction()).Throws(new DbUpdateConcurrencyException("error", new List<IUpdateEntry>() { updateEntry.Object }));

			var dbcontextMock = new Mock<DbContext>();

			ApiHealthController controller = new ApiHealthController(new Mock<ApiSettings>().Object, new Mock<ILogger<ApiHealthController>>().Object, transactionCoordinatorMock.Object, dbcontextMock.Object);

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				controller
			);

			var actionExecutedContext = new ActionExecutedContext(
				actionContext,
				new List<IFilterMetadata>(),
				controller
			);

			attribute.OnActionExecuting(actionExecutingContext);
			transactionCoordinatorMock.Verify(x => x.BeginTransaction());

			Action execute = () =>
			{
				attribute.OnActionExecuted(actionExecutedContext);
			};

			execute.Should().Throw<DbUpdateConcurrencyException>();
	}

		[Fact]
		public void UnitOfWorkFilter_GenericException()
		{
			UnitOfWorkAttribute attribute = new UnitOfWorkAttribute();

			var modelState = new ModelStateDictionary();

			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = "not null";

			var transactionCoordinatorMock = new Mock<ITransactionCoordinator>();
			var updateEntry = new Mock<IUpdateEntry>();
			transactionCoordinatorMock.Setup(x => x.CommitTransaction()).Throws(new Exception("error"));

			var dbcontextMock = new Mock<DbContext>();

			ApiHealthController controller = new ApiHealthController(new Mock<ApiSettings>().Object, new Mock<ILogger<ApiHealthController>>().Object, transactionCoordinatorMock.Object, dbcontextMock.Object);

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				controller
			);

			var actionExecutedContext = new ActionExecutedContext(
				actionContext,
				new List<IFilterMetadata>(),
				controller
			);

			attribute.OnActionExecuting(actionExecutingContext);
			transactionCoordinatorMock.Verify(x => x.BeginTransaction());

			Action execute = () =>
			{
				attribute.OnActionExecuted(actionExecutedContext);
			};

			execute.Should().Throw<Exception>();
		}

		[Fact]
		public void UnitOfWorkFilter_Rollback()
		{
			UnitOfWorkAttribute attribute = new UnitOfWorkAttribute();

			var modelState = new ModelStateDictionary();

			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = "not null";

			var transactionCoordinatorMock = new Mock<ITransactionCoordinator>();
			var updateEntry = new Mock<IUpdateEntry>();
			transactionCoordinatorMock.Setup(x => x.RollbackTransaction());

			var dbcontextMock = new Mock<DbContext>();

			ApiHealthController controller = new ApiHealthController(new Mock<ApiSettings>().Object, new Mock<ILogger<ApiHealthController>>().Object, transactionCoordinatorMock.Object, dbcontextMock.Object);

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				controller
			);

			var actionExecutedContext = new ActionExecutedContext(
				actionContext,
				new List<IFilterMetadata>(),
				controller
			);

			actionExecutedContext.Exception = new Exception();

			attribute.OnActionExecuting(actionExecutingContext);
			transactionCoordinatorMock.Verify(x => x.BeginTransaction());
			attribute.OnActionExecuted(actionExecutedContext);

			transactionCoordinatorMock.Verify(x => x.RollbackTransaction());
		}

		[Fact]
		public void UnitOfWorkFilter_Rollback_Exception()
		{
			UnitOfWorkAttribute attribute = new UnitOfWorkAttribute();

			var modelState = new ModelStateDictionary();

			var actionContext = new ActionContext(
			   new Mock<HttpContext>().Object,
			   new Mock<RouteData>().Object,
			   new Mock<ActionDescriptor>().Object,
			   modelState
		   );

			var parameters = new Dictionary<string, object>();
			parameters["item"] = "not null";

			var transactionCoordinatorMock = new Mock<ITransactionCoordinator>();
			var updateEntry = new Mock<IUpdateEntry>();
			transactionCoordinatorMock.Setup(x => x.RollbackTransaction()).Throws(new Exception());

			var dbcontextMock = new Mock<DbContext>();

			ApiHealthController controller = new ApiHealthController(new Mock<ApiSettings>().Object, new Mock<ILogger<ApiHealthController>>().Object, transactionCoordinatorMock.Object, dbcontextMock.Object);

			var actionExecutingContext = new ActionExecutingContext(
				actionContext,
				new List<IFilterMetadata>(),
				parameters,
				controller
			);

			var actionExecutedContext = new ActionExecutedContext(
				actionContext,
				new List<IFilterMetadata>(),
				controller
			);

			actionExecutedContext.Exception = new Exception();

			attribute.OnActionExecuting(actionExecutingContext);
			transactionCoordinatorMock.Verify(x => x.BeginTransaction());

			Action execute = () =>
			{
				attribute.OnActionExecuted(actionExecutedContext);
			};

			execute.Should().Throw<Exception>();
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