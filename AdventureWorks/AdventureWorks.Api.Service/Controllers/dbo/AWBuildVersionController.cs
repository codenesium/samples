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
			ApplicationContext context,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IAWBuildVersionModelValidator aWBuildVersionModelValidator
			) : base(logger,
			         context,
			         aWBuildVersionRepository,
			         aWBuildVersionModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>16d927673b033327a996f9606331291f</Hash>
</Codenesium>*/