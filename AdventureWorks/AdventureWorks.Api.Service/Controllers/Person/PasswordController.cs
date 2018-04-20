using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/passwords")]
	[ApiVersion("1.0")]
	[Response]
	public class PasswordController: AbstractPasswordController
	{
		public PasswordController(
			ServiceSettings settings,
			ILogger<PasswordController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPassword passwordManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       passwordManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>188c24ae1a7ffffa7025df00e2e5db50</Hash>
</Codenesium>*/