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
	[Route("api/links")]
	public class LinkController: AbstractLinkController
	{
		public LinkController(
			ILogger<LinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkRepository linkRepository,
			ILinkModelValidator linkModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       linkRepository,
			       linkModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6b50b0fe45fb0f051e4110f955774c68</Hash>
</Codenesium>*/