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
	[Route("api/illustrations")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(IllustrationFilter))]
	public class IllustrationController: AbstractIllustrationController
	{
		public IllustrationController(
			ILogger<IllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIllustrationRepository illustrationRepository
			)
			: base(logger,
			       transactionCoordinator,
			       illustrationRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>735c7c994541e2d7d251aab6a7f574cb</Hash>
</Codenesium>*/