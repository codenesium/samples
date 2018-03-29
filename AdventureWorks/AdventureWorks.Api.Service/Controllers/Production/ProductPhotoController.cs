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
			ApplicationContext context,
			IProductPhotoRepository productPhotoRepository,
			IProductPhotoModelValidator productPhotoModelValidator
			) : base(logger,
			         context,
			         productPhotoRepository,
			         productPhotoModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ae7abbe7fe065a2ae54b282562cf3cfd</Hash>
</Codenesium>*/