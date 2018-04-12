using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/linkStatus")]
	public class LinkStatusController: AbstractLinkStatusController
	{
		public LinkStatusController(
			ILogger<LinkStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkStatusRepository linkStatusRepository,
			ILinkStatusModelValidator linkStatusModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       linkStatusRepository,
			       linkStatusModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ba2b0769f90d1dcb6f0e46b729aa0626</Hash>
</Codenesium>*/