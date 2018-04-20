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
	[Route("api/stores")]
	[ApiVersion("1.0")]
	[Response]
	public class StoreController: AbstractStoreController
	{
		public StoreController(
			ServiceSettings settings,
			ILogger<StoreController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStore storeManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       storeManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cf3b7a9ad6be23c7fd99ccc8b8ee3e8e</Hash>
</Codenesium>*/