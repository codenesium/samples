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
	[Route("api/illustrations")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class IllustrationController: AbstractIllustrationController
	{
		public IllustrationController(
			ILogger<IllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOIllustration illustrationManager
			)
			: base(logger,
			       transactionCoordinator,
			       illustrationManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c8767f2f815fbaf7d73801160cefba4a</Hash>
</Codenesium>*/