using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/stores")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class StoreController : AbstractStoreController
	{
		public StoreController(
			ApiSettings settings,
			ILogger<StoreController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStoreService storeService,
			IApiStoreServerModelMapper storeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       storeService,
			       storeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>147a492090d5fb34ee2e7d381b2cac14</Hash>
</Codenesium>*/