using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/unitMeasures")]
	public class UnitMeasureController: AbstractUnitMeasureController
	{
		public UnitMeasureController(
			ILogger<UnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitMeasureRepository unitMeasureRepository,
			IUnitMeasureModelValidator unitMeasureModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       unitMeasureRepository,
			       unitMeasureModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>38c1ec688d11a29859d39975fc2b9905</Hash>
</Codenesium>*/