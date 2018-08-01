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

namespace OctopusDeployNS.Api.Web
{
	[Route("api/accounts")]
	[ApiController]
	[ApiVersion("1.0")]
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
    <Hash>96d2ead6e99422d22e2ba5914c59b4de</Hash>
</Codenesium>*/