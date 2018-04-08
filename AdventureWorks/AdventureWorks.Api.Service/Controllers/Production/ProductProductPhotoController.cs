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
	public class ProductProductPhotoesController: AbstractProductProductPhotoesController
	{
		public ProductProductPhotoesController(
			ILogger<ProductProductPhotoesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductProductPhotoRepository productProductPhotoRepository,
			IProductProductPhotoModelValidator productProductPhotoModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productProductPhotoRepository,
			         productProductPhotoModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bfa8912dcbf9436e1336e8e796250f6f</Hash>
</Codenesium>*/