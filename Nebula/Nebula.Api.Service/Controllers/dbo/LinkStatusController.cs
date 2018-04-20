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
	[Route("api/linkStatus")]
	[ApiVersion("1.0")]
	[Response]
	public class LinkStatusController: AbstractLinkStatusController
	{
		public LinkStatusController(
			ServiceSettings settings,
			ILogger<LinkStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLinkStatus linkStatusManager
			)
			: base(settings,
			       logger,
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
    <Hash>fae6e15a51616975e9d7be14acba5314</Hash>
</Codenesium>*/