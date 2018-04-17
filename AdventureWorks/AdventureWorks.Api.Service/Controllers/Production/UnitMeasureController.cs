using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/unitMeasures")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class UnitMeasureController: AbstractUnitMeasureController
	{
		public UnitMeasureController(
			ILogger<UnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOUnitMeasure unitMeasureManager
			)
			: base(logger,
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
    <Hash>1e8a79381ecbab70dfdd545586440a5d</Hash>
</Codenesium>*/