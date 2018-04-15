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
	public class PasswordController: AbstractPasswordController
	{
		public PasswordController(
			ILogger<PasswordController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPasswordRepository passwordRepository,
			IPasswordModelValidator passwordModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       passwordRepository,
			       passwordModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>32f6e5fd33fb33b8accc7465a1170dc9</Hash>
</Codenesium>*/