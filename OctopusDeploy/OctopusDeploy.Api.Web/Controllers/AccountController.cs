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
	[Route("api/accounts")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class AccountController : AbstractAccountController
	{
		public AccountController(
			ApiSettings settings,
			ILogger<AccountController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAccountService accountService,
			IApiAccountModelMapper accountModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       accountService,
			       accountModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8697e06eccd171569daae884e60ed866</Hash>
</Codenesium>*/