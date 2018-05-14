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
    <Hash>54cba5a6992bab137e072de044f1ad92</Hash>
</Codenesium>*/