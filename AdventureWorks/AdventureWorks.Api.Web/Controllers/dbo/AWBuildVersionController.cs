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
	[Route("api/aWBuildVersions")]
	[ApiVersion("1.0")]
	public class AWBuildVersionController: AbstractAWBuildVersionController
	{
		public AWBuildVersionController(
			ServiceSettings settings,
			ILogger<AWBuildVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAWBuildVersionService aWBuildVersionService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       aWBuildVersionService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>02e7a305f36b65ac25c6be90c97e3de9</Hash>
</Codenesium>*/