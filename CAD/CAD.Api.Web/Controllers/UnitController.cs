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
	[Route("api/units")]
	[ApiController]
	[ApiVersion("1.0")]

	public class UnitController : AbstractUnitController
	{
		public UnitController(
			ApiSettings settings,
			ILogger<UnitController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitService unitService,
			IApiUnitServerModelMapper unitModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       unitService,
			       unitModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8a57a00d1af83c23d143d3ad18e429db</Hash>
</Codenesium>*/