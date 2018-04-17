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
	[Route("api/productPhotoes")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class ProductPhotoController: AbstractProductPhotoController
	{
		public ProductPhotoController(
			ILogger<ProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductPhoto productPhotoManager
			)
			: base(logger,
			       transactionCoordinator,
			       productPhotoManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>48378f9259f7915dcd5c3925c0c607cc</Hash>
</Codenesium>*/