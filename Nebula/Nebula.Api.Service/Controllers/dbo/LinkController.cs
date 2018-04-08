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
	public class LinksController: AbstractLinksController
	{
		public LinksController(
			ILogger<LinksController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkRepository linkRepository,
			ILinkModelValidator linkModelValidator
			) : base(logger,
			         transactionCoordinator,
			         linkRepository,
			         linkModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>aef4aa306c7b0ef385504b50b3145fa9</Hash>
</Codenesium>*/