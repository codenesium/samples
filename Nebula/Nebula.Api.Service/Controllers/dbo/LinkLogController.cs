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
	[Route("api/linkLogs")]
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
    <Hash>5110b81e0c327f6d4f31a869fed2afd1</Hash>
</Codenesium>*/