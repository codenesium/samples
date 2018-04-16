using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/databaseLogs")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(DatabaseLogFilter))]
	public class DatabaseLogController: AbstractDatabaseLogController
	{
		public DatabaseLogController(
			ILogger<DatabaseLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDatabaseLogRepository databaseLogRepository
			)
			: base(logger,
			       transactionCoordinator,
			       databaseLogRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1a614f394e257a21e71d7ac98b91f0b6</Hash>
</Codenesium>*/