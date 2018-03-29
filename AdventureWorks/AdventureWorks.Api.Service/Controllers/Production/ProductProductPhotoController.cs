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
			ApplicationContext context,
			IProductProductPhotoRepository productProductPhotoRepository,
			IProductProductPhotoModelValidator productProductPhotoModelValidator
			) : base(logger,
			         context,
			         productProductPhotoRepository,
			         productProductPhotoModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0c89aee7789aa3b9f0fa704391de9771</Hash>
</Codenesium>*/