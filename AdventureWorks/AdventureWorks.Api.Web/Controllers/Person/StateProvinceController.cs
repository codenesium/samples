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
	[Route("api/stateProvinces")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class StateProvinceController : AbstractStateProvinceController
	{
		public StateProvinceController(
			ApiSettings settings,
			ILogger<StateProvinceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStateProvinceService stateProvinceService,
			IApiStateProvinceServerModelMapper stateProvinceModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       stateProvinceService,
			       stateProvinceModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>919d923ccb2a6fa32bc10e1879520105</Hash>
</Codenesium>*/