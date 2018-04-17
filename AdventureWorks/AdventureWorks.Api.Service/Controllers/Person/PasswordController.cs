using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/passwords")]
	[ApiVersion("1.0")]
	public class PasswordController: AbstractPasswordController
	{
		public PasswordController(
			ILogger<PasswordController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPassword passwordManager
			)
			: base(logger,
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
    <Hash>ad7ace853d13c3081a2f9fe8f29b71c1</Hash>
</Codenesium>*/