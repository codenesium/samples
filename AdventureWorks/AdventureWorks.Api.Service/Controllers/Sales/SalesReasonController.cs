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
	[Route("api/salesReasons")]
	public class SalesReasonsController: AbstractSalesReasonsController
	{
		public SalesReasonsController(
			ILogger<SalesReasonsController> logger,
			ApplicationContext context,
			ISalesReasonRepository salesReasonRepository,
			ISalesReasonModelValidator salesReasonModelValidator
			) : base(logger,
			         context,
			         salesReasonRepository,
			         salesReasonModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a95b948626fdc6f0396ff1050f9c2747</Hash>
</Codenesium>*/