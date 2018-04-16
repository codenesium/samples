using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/linkStatus")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(LinkStatusFilter))]
	public class LinkStatusController: AbstractLinkStatusController
	{
		public LinkStatusController(
			ILogger<LinkStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkStatusRepository linkStatusRepository
			)
			: base(logger,
			       transactionCoordinator,
			       linkStatusRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1a57109015a99cfd229687d76eabc7eb</Hash>
</Codenesium>*/