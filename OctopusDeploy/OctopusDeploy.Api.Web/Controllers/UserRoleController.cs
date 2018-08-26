using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Authorize(Policy = "DefaultAccess")]
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
    <Hash>abc15dba05d1b627c7548f5cdadd7948</Hash>
</Codenesium>*/