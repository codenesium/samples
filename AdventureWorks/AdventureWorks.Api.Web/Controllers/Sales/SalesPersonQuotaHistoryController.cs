using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/salesPersonQuotaHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class SalesPersonQuotaHistoryController : AbstractSalesPersonQuotaHistoryController
	{
		public SalesPersonQuotaHistoryController(
			ApiSettings settings,
			ILogger<SalesPersonQuotaHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonQuotaHistoryService salesPersonQuotaHistoryService,
			IApiSalesPersonQuotaHistoryModelMapper salesPersonQuotaHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesPersonQuotaHistoryService,
			       salesPersonQuotaHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4985306931cf4f8f42155e49f168729c</Hash>
</Codenesium>*/