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
	[Route("api/illustrations")]
	[ApiVersion("1.0")]
	[Response]
	public class IllustrationController: AbstractIllustrationController
	{
		public IllustrationController(
			ServiceSettings settings,
			ILogger<IllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOIllustration illustrationManager
			)
			: base(settings,
			       logger,
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
    <Hash>9a86b88f2e8b7c77920888c45d88a3b5</Hash>
</Codenesium>*/