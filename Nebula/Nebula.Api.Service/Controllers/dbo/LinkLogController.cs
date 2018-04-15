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
	[Route("api/linkLogs")]
	[ApiVersion("1.0")]
	public class LinkLogController: AbstractLinkLogController
	{
		public LinkLogController(
			ILogger<LinkLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkLogRepository linkLogRepository,
			ILinkLogModelValidator linkLogModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       linkLogRepository,
			       linkLogModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3debf3d4763655d96a04266e29913b83</Hash>
</Codenesium>*/