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
	[Route("api/cultures")]
	[ApiVersion("1.0")]
	public class CultureController: AbstractCultureController
	{
		public CultureController(
			ILogger<CultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCulture cultureManager
			)
			: base(logger,
			       transactionCoordinator,
			       cultureManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>765c1eb6e4ff2bff570d4eba10bd70a5</Hash>
</Codenesium>*/