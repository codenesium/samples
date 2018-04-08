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
	public class UnitMeasuresController: AbstractUnitMeasuresController
	{
		public UnitMeasuresController(
			ILogger<UnitMeasuresController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUnitMeasureRepository unitMeasureRepository,
			IUnitMeasureModelValidator unitMeasureModelValidator
			) : base(logger,
			         transactionCoordinator,
			         unitMeasureRepository,
			         unitMeasureModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4bf2fc9c80825317889fdb1b41dea7dc</Hash>
</Codenesium>*/