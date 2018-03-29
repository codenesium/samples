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
	[Route("api/productModelIllustrations")]
	public class ProductModelIllustrationsController: AbstractProductModelIllustrationsController
	{
		public ProductModelIllustrationsController(
			ILogger<ProductModelIllustrationsController> logger,
			ApplicationContext context,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IProductModelIllustrationModelValidator productModelIllustrationModelValidator
			) : base(logger,
			         context,
			         productModelIllustrationRepository,
			         productModelIllustrationModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e684c6d88c0f58d6f485bda1c5bcdc01</Hash>
</Codenesium>*/