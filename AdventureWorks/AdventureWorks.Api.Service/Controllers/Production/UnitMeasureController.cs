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
			ApplicationContext context,
			IUnitMeasureRepository unitMeasureRepository,
			IUnitMeasureModelValidator unitMeasureModelValidator
			) : base(logger,
			         context,
			         unitMeasureRepository,
			         unitMeasureModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d9c8ba500ffd165b43ddaed05a904a61</Hash>
</Codenesium>*/