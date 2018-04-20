using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/databaseLogs")]
	[ApiVersion("1.0")]
	[Response]
	public class DatabaseLogController: AbstractDatabaseLogController
	{
		public DatabaseLogController(
			ServiceSettings settings,
			ILogger<DatabaseLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODatabaseLog databaseLogManager
			)
			: base(settings,
			       logger,
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
    <Hash>21e65defa340c2d761288b50c0264fba</Hash>
</Codenesium>*/