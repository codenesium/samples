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
	[Route("api/aWBuildVersions")]
	[ApiVersion("1.0")]
	public class AWBuildVersionController: AbstractAWBuildVersionController
	{
		public AWBuildVersionController(
			ILogger<AWBuildVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAWBuildVersion aWBuildVersionManager
			)
			: base(logger,
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
    <Hash>70c7725e4e18201328bc82fe71a062d9</Hash>
</Codenesium>*/