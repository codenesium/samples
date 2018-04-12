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
    <Hash>229e464c3d51add79569783bbbab4f59</Hash>
</Codenesium>*/