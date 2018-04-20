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
	[Route("api/cultures")]
	[ApiVersion("1.0")]
	[Response]
	public class CultureController: AbstractCultureController
	{
		public CultureController(
			ServiceSettings settings,
			ILogger<CultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCulture cultureManager
			)
			: base(settings,
			       logger,
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
    <Hash>f9b9dea296f138aca662fb6a4d5b0d22</Hash>
</Codenesium>*/