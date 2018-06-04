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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/stores")]
	[ApiVersion("1.0")]
	public class StoreController: AbstractStoreController
	{
		public StoreController(
			ServiceSettings settings,
			ILogger<StoreController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStoreService storeService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       storeService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dac37306f0e97bce3c4ed254e8b82f16</Hash>
</Codenesium>*/