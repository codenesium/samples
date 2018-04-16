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
	[Route("api/aWBuildVersions")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(AWBuildVersionFilter))]
	public class AWBuildVersionController: AbstractAWBuildVersionController
	{
		public AWBuildVersionController(
			ILogger<AWBuildVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAWBuildVersionRepository aWBuildVersionRepository
			)
			: base(logger,
			       transactionCoordinator,
			       aWBuildVersionRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>782381843145c792270ca41b89937aed</Hash>
</Codenesium>*/