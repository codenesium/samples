using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/passwords")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PasswordController : AbstractPasswordController
	{
		public PasswordController(
			ApiSettings settings,
			ILogger<PasswordController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPasswordService passwordService,
			IApiPasswordModelMapper passwordModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       passwordService,
			       passwordModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>45cf9163a9702a0d758b2d43421562e5</Hash>
</Codenesium>*/