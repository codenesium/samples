using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/linkLogs")]
	[ApiVersion("1.0")]
	public class LinkLogController: AbstractLinkLogController
	{
		public LinkLogController(
			ServiceSettings settings,
			ILogger<LinkLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLinkLog linkLogManager
			)
			: base(settings,
			       logger,
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
    <Hash>0cd036ed156fab97defa5b2c6f378648</Hash>
</Codenesium>*/