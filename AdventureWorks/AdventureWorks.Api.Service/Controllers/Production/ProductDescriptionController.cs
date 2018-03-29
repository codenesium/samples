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
	[Route("api/productDescriptions")]
	public class ProductDescriptionsController: AbstractProductDescriptionsController
	{
		public ProductDescriptionsController(
			ILogger<ProductDescriptionsController> logger,
			ApplicationContext context,
			IProductDescriptionRepository productDescriptionRepository,
			IProductDescriptionModelValidator productDescriptionModelValidator
			) : base(logger,
			         context,
			         productDescriptionRepository,
			         productDescriptionModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>71c5cace1bf9076c0276ed60798724b7</Hash>
</Codenesium>*/