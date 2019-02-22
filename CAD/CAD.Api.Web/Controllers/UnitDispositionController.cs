using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web
{
	[Route("api/unitDispositions")]
	[ApiController]
	[ApiVersion("1.0")]

	public class UnitDispositionController : AbstractUnitDispositionController
	{
		public UnitDispositionController(
			ApiSettings settings,
			ILogger<UnitDispositionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitDispositionService unitDispositionService,
			IApiUnitDispositionServerModelMapper unitDispositionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       unitDispositionService,
			       unitDispositionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a24cc18b92f91804c47795d325ae1938</Hash>
</Codenesium>*/