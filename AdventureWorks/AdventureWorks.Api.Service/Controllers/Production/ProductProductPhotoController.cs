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
	[Route("api/productProductPhotoes")]
	[ApiVersion("1.0")]
	public class ProductProductPhotoController: AbstractProductProductPhotoController
	{
		public ProductProductPhotoController(
			ILogger<ProductProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductProductPhoto productProductPhotoManager
			)
			: base(logger,
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
    <Hash>754ad84b85be661843d20ed54d0059b5</Hash>
</Codenesium>*/