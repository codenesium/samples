using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/linkLogs")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class LinkLogController: AbstractLinkLogController
	{
		public LinkLogController(
			ILogger<LinkLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLinkLog linkLogManager
			)
			: base(logger,
			       transactionCoordinator,
			       linkLogManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f46e1cf3efa893188e07d2111bdb9dec</Hash>
</Codenesium>*/