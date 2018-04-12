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
	[Route("api/salesPersonQuotaHistories")]
	public class SalesPersonQuotaHistoryController: AbstractSalesPersonQuotaHistoryController
	{
		public SalesPersonQuotaHistoryController(
			ILogger<SalesPersonQuotaHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       salesPersonQuotaHistoryRepository,
			       salesPersonQuotaHistoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>88683ae179e624554d8f41602d3d75a9</Hash>
</Codenesium>*/