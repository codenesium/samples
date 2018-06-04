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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/illustrations")]
	[ApiVersion("1.0")]
	public class IllustrationController: AbstractIllustrationController
	{
		public IllustrationController(
			ServiceSettings settings,
			ILogger<IllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIllustrationService illustrationService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       illustrationService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1c1c33dd36522ee072e48fbc0d3540a3</Hash>
</Codenesium>*/