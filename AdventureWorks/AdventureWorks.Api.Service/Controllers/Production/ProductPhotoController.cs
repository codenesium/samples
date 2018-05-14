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
	[Route("api/productPhotoes")]
	[ApiVersion("1.0")]
	public class ProductPhotoController: AbstractProductPhotoController
	{
		public ProductPhotoController(
			ServiceSettings settings,
			ILogger<ProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductPhoto productPhotoManager
			)
			: base(settings,
			       logger,
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
    <Hash>b7a1259f4bac8419f1cf1cede668e600</Hash>
</Codenesium>*/