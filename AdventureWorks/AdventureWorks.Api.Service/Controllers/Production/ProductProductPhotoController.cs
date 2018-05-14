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
	[Route("api/productProductPhotoes")]
	[ApiVersion("1.0")]
	public class ProductProductPhotoController: AbstractProductProductPhotoController
	{
		public ProductProductPhotoController(
			ServiceSettings settings,
			ILogger<ProductProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductProductPhoto productProductPhotoManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productProductPhotoManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8654886ff0fe1b4f2633bfb83be11d3c</Hash>
</Codenesium>*/