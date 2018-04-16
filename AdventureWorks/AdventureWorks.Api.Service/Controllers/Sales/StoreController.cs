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
	[ServiceFilter(typeof(StoreFilter))]
	public class StoreController: AbstractStoreController
	{
		public StoreController(
			ILogger<StoreController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStoreRepository storeRepository
			)
			: base(logger,
			       transactionCoordinator,
			       storeRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>292a73254126f8ed4901248249ed4a89</Hash>
</Codenesium>*/