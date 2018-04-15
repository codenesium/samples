using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/stores")]
	[ApiVersion("1.0")]
	public class StoreController: AbstractStoreController
	{
		public StoreController(
			ILogger<StoreController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStoreRepository storeRepository,
			IStoreModelValidator storeModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       storeRepository,
			       storeModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>129a3f8c112e3590a98f54d994bb76e3</Hash>
</Codenesium>*/