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
	[Route("api/cultures")]
	public class CultureController: AbstractCultureController
	{
		public CultureController(
			ILogger<CultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICultureRepository cultureRepository,
			ICultureModelValidator cultureModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       cultureRepository,
			       cultureModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dd70e3b703c6a5918970b29e20f3329c</Hash>
</Codenesium>*/