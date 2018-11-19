using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
			IApiPasswordServerModelMapper passwordModelMapper
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
    <Hash>204ac952fa65a54d6eacc6591b447283</Hash>
</Codenesium>*/