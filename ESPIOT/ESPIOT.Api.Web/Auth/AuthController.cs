using Codenesium.Foundation.CommonMVC;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using ESPIOTNS.Api.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Web.Auth
{
	[Route("api/auth")]
	[ApiController]
	[ApiVersion("1.0")]
	[AllowAnonymous]

	public class AuthController : AbstractApiController
	{
		private ApiSettings settings;
		private ILogger<AuthController> logger;
		private ITransactionCoordinator transactionCoordinator;
		private IAuthService authService;

		public AuthController(
			ApiSettings settings,
			ILogger<AuthController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAuthService authService
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.authService = authService;
		}


		[HttpPost]
		[Route("authenticate")]
		[UnitOfWork]
		[ProducesResponseType(typeof(AuthenticateResponseModel), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ActionResponse), StatusCodes.Status401Unauthorized)]

		public virtual async Task<IActionResult> Authenticate([FromBody] AuthenticateRequestModel model)
		{
			AuthenticateResponseModel result = await this.authService.Authenticate(model);

			if (result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, result);
			}
		}

		[HttpPost]
		[Route("register")]
		[UnitOfWork]
		[ProducesResponseType(typeof(RegisterResponseModel), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ActionResponse), StatusCodes.Status401Unauthorized)]

		public virtual async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
		{
			RegisterResponseModel result = await this.authService.Register(model);

			if (result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, result);
			}
		}

		[HttpPost]
		[Route("resetpassword")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ResetPasswordResponseModel), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ActionResponse), StatusCodes.Status401Unauthorized)]

		public virtual async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestModel model)
		{
			ResetPasswordResponseModel result = await this.authService.ResetPassword(model);

			if (result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, result);
			}
		}
	}
}