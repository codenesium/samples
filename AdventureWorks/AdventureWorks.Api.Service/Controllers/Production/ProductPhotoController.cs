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
	public class ProductPhotoesController: AbstractProductPhotoesController
	{
		public ProductPhotoesController(
			ILogger<ProductPhotoesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductPhotoRepository productPhotoRepository,
			IProductPhotoModelValidator productPhotoModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productPhotoRepository,
			         productPhotoModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2968cac561771e0c4ea3d09f472566ef</Hash>
</Codenesium>*/