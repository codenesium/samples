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
	[Route("api/productModelProductDescriptionCultures")]
	public class ProductModelProductDescriptionCulturesController: AbstractProductModelProductDescriptionCulturesController
	{
		public ProductModelProductDescriptionCulturesController(
			ILogger<ProductModelProductDescriptionCulturesController> logger,
			ApplicationContext context,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator
			) : base(logger,
			         context,
			         productModelProductDescriptionCultureRepository,
			         productModelProductDescriptionCultureModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>95a2d3a7defd5d850050bd47fd3d5ae6</Hash>
</Codenesium>*/