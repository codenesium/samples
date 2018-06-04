using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/unitMeasures")]
	[ApiVersion("1.0")]
	public class UnitMeasureController: AbstractUnitMeasureController
	{
		public UnitMeasureController(
			ServiceSettings settings,
			ILogger<UnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitMeasureService unitMeasureService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       unitMeasureService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>116bab713bff192becbb6fcfc31dd29d</Hash>
</Codenesium>*/