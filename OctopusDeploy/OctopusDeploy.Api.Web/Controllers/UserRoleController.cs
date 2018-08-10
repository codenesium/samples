using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/userRoles")]
	[ApiController]
	[ApiVersion("1.0")]
	public class UserRoleController : AbstractUserRoleController
	{
		public UserRoleController(
			ApiSettings settings,
			ILogger<UserRoleController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUserRoleService userRoleService,
			IApiUserRoleModelMapper userRoleModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       userRoleService,
			       userRoleModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5ba01d17e3f34f7c69f21dbd47715cc2</Hash>
</Codenesium>*/