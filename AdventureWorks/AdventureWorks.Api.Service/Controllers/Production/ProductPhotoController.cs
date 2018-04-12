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
	[Route("api/productPhotoes")]
	public class ProductPhotoController: AbstractProductPhotoController
	{
		public ProductPhotoController(
			ILogger<ProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductPhotoRepository productPhotoRepository,
			IProductPhotoModelValidator productPhotoModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productPhotoRepository,
			       productPhotoModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>703ed098a868296e7290da2db85467dc</Hash>
</Codenesium>*/