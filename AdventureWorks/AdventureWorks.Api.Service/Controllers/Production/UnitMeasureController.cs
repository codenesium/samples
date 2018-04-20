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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/unitMeasures")]
	[ApiVersion("1.0")]
	[Response]
	public class UnitMeasureController: AbstractUnitMeasureController
	{
		public UnitMeasureController(
			ServiceSettings settings,
			ILogger<UnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOUnitMeasure unitMeasureManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       unitMeasureManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8275031d1077c10c863321dc0c03ee2d</Hash>
</Codenesium>*/