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
	public class SalesPersonQuotaHistoriesController: AbstractSalesPersonQuotaHistoriesController
	{
		public SalesPersonQuotaHistoriesController(
			ILogger<SalesPersonQuotaHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesPersonQuotaHistoryRepository,
			         salesPersonQuotaHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>af77e17b5a23952ea4cbef0db89c41cf</Hash>
</Codenesium>*/