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
	[Route("api/linkStatus")]
	[ApiVersion("1.0")]
	public class LinkStatusController: AbstractLinkStatusController
	{
		public LinkStatusController(
			ILogger<LinkStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLinkStatus linkStatusManager
			)
			: base(logger,
			       transactionCoordinator,
			       linkStatusManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b15ff23d1494e93b3d9b87d0ed7f2933</Hash>
</Codenesium>*/