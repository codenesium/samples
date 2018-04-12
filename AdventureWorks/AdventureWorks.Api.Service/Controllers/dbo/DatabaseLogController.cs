using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/databaseLogs")]
	public class DatabaseLogController: AbstractDatabaseLogController
	{
		public DatabaseLogController(
			ILogger<DatabaseLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDatabaseLogRepository databaseLogRepository,
			IDatabaseLogModelValidator databaseLogModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       databaseLogRepository,
			       databaseLogModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e3eee6e8801bb03bdaf8593588bae11a</Hash>
</Codenesium>*/