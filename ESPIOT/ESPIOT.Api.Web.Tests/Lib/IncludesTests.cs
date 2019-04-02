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
using System.Threading.Tasks;
using System.Net;
using System.Security.Principal;
using System.Security.Claims;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;

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

		[Fact]
		public void SearchQuery_Process()
		{
			var searchQuery = new SearchQuery();

			var parameters = new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>();
			parameters["aParameter"] = "t";

			var response = searchQuery.Process(5, 5, 1, 0, "test", parameters);
			searchQuery.Limit.Should().Be(1);
			searchQuery.Offset.Should().Be(0);
			searchQuery.Query.Should().Be("test");
			searchQuery.QueryParameters.Should().BeEquivalentTo(parameters);
			response.Should().Be(true);
			searchQuery.Error.Should().BeEmpty();
		}

		[Fact]
		public void SearchQuery_Process_InvalidLimit()
		{
			var searchQuery = new SearchQuery();

			var response = searchQuery.Process(5, 5, 10, 0, "test", new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

			response.Should().Be(false);
			searchQuery.Error.Should().Be($"Limit of 10 exceeds maximum request size of 5 records");
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Lib")]
	public class AuthTests
	{ 
		[Fact]
		public async void LoginSuccess()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(true);
			authService.Setup(x => x.Login(It.IsAny<LoginRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.Login(new LoginRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			((response as OkObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.Login(It.IsAny<LoginRequestModel>()));
		}

		[Fact]
		public async void LoginFailure()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(false);
			authService.Setup(x => x.Login(It.IsAny<LoginRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.Login(new LoginRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.Login(It.IsAny<LoginRequestModel>()));
		}

		[Fact]
		public async void RegisterSuccess()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(true);
			authService.Setup(x => x.Register(It.IsAny<RegisterRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.Register(new RegisterRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			((response as OkObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.Register(It.IsAny<RegisterRequestModel>()));
		}
	
		[Fact]
		public async void RegisterFailure()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(false);
			authService.Setup(x => x.Register(It.IsAny<RegisterRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.Register(new RegisterRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.Register(It.IsAny<RegisterRequestModel>()));
		}

		[Fact]
		public async void ChangePasswordSuccess()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				 new Claim(ClaimTypes.Email, "test@test.com"),
			}));

			controller.ControllerContext = new ControllerContext()
			{
				HttpContext = new DefaultHttpContext()
				{
					User = user
				}
			};

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(true);
			authService.Setup(x => x.ChangePassword(It.IsAny<ChangePasswordRequestModel>(), It.IsAny<string>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ChangePassword(new ChangePasswordRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			((response as OkObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ChangePassword(It.IsAny<ChangePasswordRequestModel>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ChangePasswordFailure()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				 new Claim(ClaimTypes.Email, "test@test.com"),
			}));

			controller.ControllerContext = new ControllerContext()
			{
				HttpContext = new DefaultHttpContext()
				{
					User = user
				}
			};

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(false);
			authService.Setup(x => x.ChangePassword(It.IsAny<ChangePasswordRequestModel>(), It.IsAny<string>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ChangePassword(new ChangePasswordRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ChangePassword(It.IsAny<ChangePasswordRequestModel>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ChangeEmailSuccess()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				 new Claim(ClaimTypes.Email, "test@test.com"),
			}));

			controller.ControllerContext = new ControllerContext()
			{
				HttpContext = new DefaultHttpContext()
				{
					User = user
				}
			};

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(true);
			authService.Setup(x => x.ChangeEmail(It.IsAny<ChangeEmailRequestModel>(), It.IsAny<string>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ChangeEmail(new ChangeEmailRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			((response as OkObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ChangeEmail(It.IsAny<ChangeEmailRequestModel>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ChangeEmailFailure()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				 new Claim(ClaimTypes.Email, "test@test.com"),
			}));

			controller.ControllerContext = new ControllerContext()
			{
				HttpContext = new DefaultHttpContext()
				{
					User = user
				}
			};

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(false);
			authService.Setup(x => x.ChangeEmail(It.IsAny<ChangeEmailRequestModel>(), It.IsAny<string>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ChangeEmail(new ChangeEmailRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ChangeEmail(It.IsAny<ChangeEmailRequestModel>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ResetPasswordSuccess()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(true);
			authService.Setup(x => x.ResetPassword(It.IsAny<ResetPasswordRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ResetPassword(new ResetPasswordRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			((response as OkObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ResetPassword(It.IsAny<ResetPasswordRequestModel>()));
		}

		[Fact]
		public async void ResetPasswordFailure()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(false);
			authService.Setup(x => x.ResetPassword(It.IsAny<ResetPasswordRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ResetPassword(new ResetPasswordRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ResetPassword(It.IsAny<ResetPasswordRequestModel>()));
		}

		[Fact]
		public async void ConfirmRegistrationSuccess()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(true);
			authService.Setup(x => x.ConfirmRegistration(It.IsAny<ConfirmRegistrationRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ConfirmRegistration(new ConfirmRegistrationRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ConfirmRegistration(It.IsAny<ConfirmRegistrationRequestModel>()));
		}

		[Fact]
		public async void ConfirmRegistrationFailure()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(false);
			authService.Setup(x => x.ConfirmRegistration(It.IsAny<ConfirmRegistrationRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ConfirmRegistration(new ConfirmRegistrationRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ConfirmRegistration(It.IsAny<ConfirmRegistrationRequestModel>()));
		}

		[Fact]
		public async void ConfirmResetPasswordSuccess()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(true);
			authService.Setup(x => x.ConfirmPasswordReset(It.IsAny<ConfirmPasswordResetRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ConfirmPasswordReset(new ConfirmPasswordResetRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ConfirmPasswordReset(It.IsAny<ConfirmPasswordResetRequestModel>()));
		}

		[Fact]
		public async void ConfirmResetPasswordFailure()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(false);
			authService.Setup(x => x.ConfirmPasswordReset(It.IsAny<ConfirmPasswordResetRequestModel>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ConfirmPasswordReset(new ConfirmPasswordResetRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ConfirmPasswordReset(It.IsAny<ConfirmPasswordResetRequestModel>()));
		}

		[Fact]
		public async void ConfirmChangeEmailSuccess()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Email, "test@test.com"),
			}));

			controller.ControllerContext = new ControllerContext()
			{
				HttpContext = new DefaultHttpContext()
				{
					User = user
				}
			};

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(true);
			authService.Setup(x => x.ConfirmChangeEmail(It.IsAny<ConfirmChangeEmailRequestModel>(), It.IsAny<string>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ConfirmChangeEmail(new ConfirmChangeEmailRequestModel());

			response.Should().BeOfType<OkObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ConfirmChangeEmail(It.IsAny<ConfirmChangeEmailRequestModel>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ConfirmChangeEmailFailure()
		{
			Mock<ApiSettings> apiSettings = new Mock<ApiSettings>();
			Mock<IAuthService> authService = new Mock<IAuthService>();
			Mock<ITransactionCoordinator> transactionCoordinator = new Mock<ITransactionCoordinator>();
			Mock<ILogger<AuthController>> logger = new Mock<ILogger<AuthController>>();
			AuthController controller = new AuthController(apiSettings.Object, logger.Object, transactionCoordinator.Object, authService.Object);

			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Email, "test@test.com"),
			}));

			controller.ControllerContext = new ControllerContext()
			{
				HttpContext = new DefaultHttpContext()
				{
					User = user
				}
			};

			Mock<AuthResponse> authResponse = new Mock<AuthResponse>();
			authResponse.SetupGet(x => x.Success).Returns(false);
			authService.Setup(x => x.ConfirmChangeEmail(It.IsAny<ConfirmChangeEmailRequestModel>(), It.IsAny<string>())).Returns(Task.FromResult(authResponse.Object));

			IActionResult response = await controller.ConfirmChangeEmail(new ConfirmChangeEmailRequestModel());

			response.Should().BeOfType<ObjectResult>();
			(response as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
			((response as ObjectResult).Value as AuthResponse).Should().NotBeNull();
			authService.Verify(x => x.ConfirmChangeEmail(It.IsAny<ConfirmChangeEmailRequestModel>(), It.IsAny<string>()));
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
                        : base(options, null)
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