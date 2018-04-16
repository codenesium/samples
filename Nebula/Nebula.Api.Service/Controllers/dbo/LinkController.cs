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
	[Route("api/links")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(LinkFilter))]
	public class LinkController: AbstractLinkController
	{
		public LinkController(
			ILogger<LinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkRepository linkRepository
			)
			: base(logger,
			       transactionCoordinator,
			       linkRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7eeda3273ea9cf9b6fcccf7c911ea707</Hash>
</Codenesium>*/