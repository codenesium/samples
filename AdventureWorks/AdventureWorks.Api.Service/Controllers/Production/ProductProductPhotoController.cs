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
	[Response]
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
    <Hash>0819c7c26fada466444a2b8b22cfe1cb</Hash>
</Codenesium>*/