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
	[ResponseFilter]
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
    <Hash>98126b34f655621e4cb0d727ae9b9345</Hash>
</Codenesium>*/