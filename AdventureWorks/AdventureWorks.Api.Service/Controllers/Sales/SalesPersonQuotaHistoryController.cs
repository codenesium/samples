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
	[Route("api/salesPersonQuotaHistories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SalesPersonQuotaHistoryFilter))]
	public class SalesPersonQuotaHistoryController: AbstractSalesPersonQuotaHistoryController
	{
		public SalesPersonQuotaHistoryController(
			ILogger<SalesPersonQuotaHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       salesPersonQuotaHistoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f1e2c7b08ef56532cc7a7563965e365c</Hash>
</Codenesium>*/