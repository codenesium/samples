using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/salesPersonQuotaHistories")]
	[ApiVersion("1.0")]
	[Response]
	public class SalesPersonQuotaHistoryController: AbstractSalesPersonQuotaHistoryController
	{
		public SalesPersonQuotaHistoryController(
			ServiceSettings settings,
			ILogger<SalesPersonQuotaHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesPersonQuotaHistory salesPersonQuotaHistoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesPersonQuotaHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4b22c3db6418313e4d1fc89e6dd6b717</Hash>
</Codenesium>*/