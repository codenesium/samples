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
	[Route("api/aWBuildVersions")]
	public class AWBuildVersionController: AbstractAWBuildVersionController
	{
		public AWBuildVersionController(
			ILogger<AWBuildVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IAWBuildVersionModelValidator aWBuildVersionModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       aWBuildVersionRepository,
			       aWBuildVersionModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ac1f1214c7ae9c26f70f86625f417ddd</Hash>
</Codenesium>*/