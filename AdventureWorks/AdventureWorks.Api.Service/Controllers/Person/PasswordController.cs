using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/passwords")]
	public class PasswordsController: AbstractPasswordsController
	{
		public PasswordsController(
			ILogger<PasswordsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPasswordRepository passwordRepository,
			IPasswordModelValidator passwordModelValidator
			) : base(logger,
			         transactionCoordinator,
			         passwordRepository,
			         passwordModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d32f889286fa9796610185745ae680e5</Hash>
</Codenesium>*/