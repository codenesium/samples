using Codenesium.Foundation.CommonMVC;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Web
{
	[Route("api/efmigrationshistories")]
	[ApiController]
	[ApiVersion("1.0")]

	public class EfmigrationshistoryController : AbstractEfmigrationshistoryController
	{
		public EfmigrationshistoryController(
			ApiSettings settings,
			ILogger<EfmigrationshistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEfmigrationshistoryService efmigrationshistoryService,
			IApiEfmigrationshistoryServerModelMapper efmigrationshistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       efmigrationshistoryService,
			       efmigrationshistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3f78463f1eddc4708070f7487119d4de</Hash>
</Codenesium>*/