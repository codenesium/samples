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
    <Hash>96733867b1c1c8147ddd76e534c2cba9</Hash>
</Codenesium>*/