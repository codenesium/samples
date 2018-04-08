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
	public class AWBuildVersionsController: AbstractAWBuildVersionsController
	{
		public AWBuildVersionsController(
			ILogger<AWBuildVersionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IAWBuildVersionModelValidator aWBuildVersionModelValidator
			) : base(logger,
			         transactionCoordinator,
			         aWBuildVersionRepository,
			         aWBuildVersionModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>36d4c475924a3f9c0fbaf400582247d7</Hash>
</Codenesium>*/