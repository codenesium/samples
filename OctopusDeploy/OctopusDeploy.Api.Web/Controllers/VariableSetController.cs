using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/variableSets")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class VariableSetController : AbstractVariableSetController
	{
		public VariableSetController(
			ApiSettings settings,
			ILogger<VariableSetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVariableSetService variableSetService,
			IApiVariableSetModelMapper variableSetModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       variableSetService,
			       variableSetModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7319706557f0940b76b095474dc99c4b</Hash>
</Codenesium>*/