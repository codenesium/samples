using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/passwords")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(PasswordFilter))]
	public class PasswordController: AbstractPasswordController
	{
		public PasswordController(
			ILogger<PasswordController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPasswordRepository passwordRepository
			)
			: base(logger,
			       transactionCoordinator,
			       passwordRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>29fb183dcbff3b12c666fd8ec53f9003</Hash>
</Codenesium>*/