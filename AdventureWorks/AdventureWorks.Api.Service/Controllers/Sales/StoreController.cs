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
	public class StoresController: AbstractStoresController
	{
		public StoresController(
			ILogger<StoresController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStoreRepository storeRepository,
			IStoreModelValidator storeModelValidator
			) : base(logger,
			         transactionCoordinator,
			         storeRepository,
			         storeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>23411c96e90f57c47285334d3f86f84a</Hash>
</Codenesium>*/