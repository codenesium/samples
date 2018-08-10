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
	[Route("api/stores")]
	[ApiController]
	[ApiVersion("1.0")]
	public class StoreController : AbstractStoreController
	{
		public StoreController(
			ApiSettings settings,
			ILogger<StoreController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStoreService storeService,
			IApiStoreModelMapper storeModelMapper
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
    <Hash>47e8889e7984ceaa256dbff7b5adb242</Hash>
</Codenesium>*/