using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/databaseLogs")]
	[ApiVersion("1.0")]
	public class DatabaseLogController: AbstractDatabaseLogController
	{
		public DatabaseLogController(
			ILogger<DatabaseLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODatabaseLog databaseLogManager
			)
			: base(logger,
			       transactionCoordinator,
			       databaseLogManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8f05f7a2b488d90b627fbfa777a63b92</Hash>
</Codenesium>*/