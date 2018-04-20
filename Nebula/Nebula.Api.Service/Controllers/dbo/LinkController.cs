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
	[Route("api/links")]
	[ApiVersion("1.0")]
	[Response]
	public class LinkController: AbstractLinkController
	{
		public LinkController(
			ServiceSettings settings,
			ILogger<LinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLink linkManager
			)
			: base(settings,
			       logger,
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
    <Hash>289c8761879659489e014a6e067fdec5</Hash>
</Codenesium>*/