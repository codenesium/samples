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
			ITransactionCoordinator transactionCoordinator,
			ISalesReasonRepository salesReasonRepository,
			ISalesReasonModelValidator salesReasonModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesReasonRepository,
			         salesReasonModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2f3cd423864eb0909b68492737e8d872</Hash>
</Codenesium>*/