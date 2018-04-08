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
	public class DatabaseLogsController: AbstractDatabaseLogsController
	{
		public DatabaseLogsController(
			ILogger<DatabaseLogsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDatabaseLogRepository databaseLogRepository,
			IDatabaseLogModelValidator databaseLogModelValidator
			) : base(logger,
			         transactionCoordinator,
			         databaseLogRepository,
			         databaseLogModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ddd88f53eb0f824ad0f90c06609ce1c1</Hash>
</Codenesium>*/