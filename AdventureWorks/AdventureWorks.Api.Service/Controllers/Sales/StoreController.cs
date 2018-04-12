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
	[Route("api/stores")]
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
    <Hash>cdcd09b0f4a5cfcfae7a4a22a3dd39be</Hash>
</Codenesium>*/