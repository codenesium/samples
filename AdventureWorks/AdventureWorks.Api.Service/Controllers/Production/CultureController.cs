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
    <Hash>5fa0dd9b2040c06ee856a126720414a7</Hash>
</Codenesium>*/