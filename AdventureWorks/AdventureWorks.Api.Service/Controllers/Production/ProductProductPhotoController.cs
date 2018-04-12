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
	[Route("api/productProductPhotoes")]
	public class ProductProductPhotoController: AbstractProductProductPhotoController
	{
		public ProductProductPhotoController(
			ILogger<ProductProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductProductPhotoRepository productProductPhotoRepository,
			IProductProductPhotoModelValidator productProductPhotoModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productProductPhotoRepository,
			       productProductPhotoModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>27d6ce31c50454658a8a43dc7ae78f20</Hash>
</Codenesium>*/