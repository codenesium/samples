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
    <Hash>0cee9254924388c46ef5add7fcb5fd1e</Hash>
</Codenesium>*/