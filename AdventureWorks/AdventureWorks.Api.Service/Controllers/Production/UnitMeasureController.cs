using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/unitMeasures")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(UnitMeasureFilter))]
	public class UnitMeasureController: AbstractUnitMeasureController
	{
		public UnitMeasureController(
			ILogger<UnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitMeasureRepository unitMeasureRepository
			)
			: base(logger,
			       transactionCoordinator,
			       unitMeasureRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fdb676bac79e8fc10588ca08fb1e61dc</Hash>
</Codenesium>*/