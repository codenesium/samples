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
	[Route("api/unitMeasures")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class UnitMeasureController : AbstractUnitMeasureController
	{
		public UnitMeasureController(
			ApiSettings settings,
			ILogger<UnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitMeasureService unitMeasureService,
			IApiUnitMeasureServerModelMapper unitMeasureModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       unitMeasureService,
			       unitMeasureModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7b99db3fc4fc35834db1a9d14467cc83</Hash>
</Codenesium>*/