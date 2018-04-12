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
	[Route("api/illustrations")]
	public class IllustrationController: AbstractIllustrationController
	{
		public IllustrationController(
			ILogger<IllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIllustrationRepository illustrationRepository,
			IIllustrationModelValidator illustrationModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       illustrationRepository,
			       illustrationModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2f26d26fda843ec99dbb5f80e9f60c8d</Hash>
</Codenesium>*/