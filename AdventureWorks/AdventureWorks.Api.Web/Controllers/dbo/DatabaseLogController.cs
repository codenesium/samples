using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/databaseLogs")]
	[ApiController]
	[ApiVersion("1.0")]
	public class DatabaseLogController : AbstractDatabaseLogController
	{
		public DatabaseLogController(
			ApiSettings settings,
			ILogger<DatabaseLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDatabaseLogService databaseLogService,
			IApiDatabaseLogModelMapper databaseLogModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       databaseLogService,
			       databaseLogModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2d017a04057964e01caf860ad656b30e</Hash>
</Codenesium>*/