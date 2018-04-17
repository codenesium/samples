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
	[Route("api/links")]
	[ApiVersion("1.0")]
	public class LinkController: AbstractLinkController
	{
		public LinkController(
			ILogger<LinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLink linkManager
			)
			: base(logger,
			       transactionCoordinator,
			       linkManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>60e7cc85fefaed625046d23a0ad082ab</Hash>
</Codenesium>*/