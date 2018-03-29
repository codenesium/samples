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
			ApplicationContext context,
			IDatabaseLogRepository databaseLogRepository,
			IDatabaseLogModelValidator databaseLogModelValidator
			) : base(logger,
			         context,
			         databaseLogRepository,
			         databaseLogModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>406641efc6f4b027e86adaea5bdbaba2</Hash>
</Codenesium>*/