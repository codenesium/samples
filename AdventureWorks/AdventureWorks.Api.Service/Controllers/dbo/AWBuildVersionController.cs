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
	[Route("api/aWBuildVersions")]
	[ApiVersion("1.0")]
	[Response]
	public class AWBuildVersionController: AbstractAWBuildVersionController
	{
		public AWBuildVersionController(
			ServiceSettings settings,
			ILogger<AWBuildVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAWBuildVersion aWBuildVersionManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       aWBuildVersionManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d21f268a93dd128405fce26bff611a22</Hash>
</Codenesium>*/