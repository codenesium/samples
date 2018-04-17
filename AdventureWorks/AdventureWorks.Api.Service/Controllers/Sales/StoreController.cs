using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/stores")]
	[ApiVersion("1.0")]
	public class StoreController: AbstractStoreController
	{
		public StoreController(
			ILogger<StoreController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStore storeManager
			)
			: base(logger,
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
    <Hash>5a9957580d680a9448a5d5f4adf68c92</Hash>
</Codenesium>*/