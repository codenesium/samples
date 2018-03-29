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
			ApplicationContext context,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator
			) : base(logger,
			         context,
			         salesPersonQuotaHistoryRepository,
			         salesPersonQuotaHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>47ab5552312e752e38562ff326d64a63</Hash>
</Codenesium>*/