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
			ApplicationContext context,
			IStoreRepository storeRepository,
			IStoreModelValidator storeModelValidator
			) : base(logger,
			         context,
			         storeRepository,
			         storeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4db3a96084064bce31a83ac5cd5e54cb</Hash>
</Codenesium>*/