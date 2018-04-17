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
    <Hash>68838fcdb8f092e031404d3b569c57b5</Hash>
</Codenesium>*/