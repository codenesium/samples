using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/aWBuildVersions")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class AWBuildVersionController : AbstractAWBuildVersionController
	{
		public AWBuildVersionController(
			ApiSettings settings,
			ILogger<AWBuildVersionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAWBuildVersionService aWBuildVersionService,
			IApiAWBuildVersionServerModelMapper aWBuildVersionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       aWBuildVersionService,
			       aWBuildVersionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dca8bc451b7fc7b29744c81c43208ae8</Hash>
</Codenesium>*/