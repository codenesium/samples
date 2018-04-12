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
	public class SalesReasonController: AbstractSalesReasonController
	{
		public SalesReasonController(
			ILogger<SalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesReasonRepository salesReasonRepository,
			ISalesReasonModelValidator salesReasonModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       salesReasonRepository,
			       salesReasonModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ad7210b4c63601e3bb375a663928fdb2</Hash>
</Codenesium>*/