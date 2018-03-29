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
	[Route("api/productVendors")]
	public class ProductVendorsController: AbstractProductVendorsController
	{
		public ProductVendorsController(
			ILogger<ProductVendorsController> logger,
			ApplicationContext context,
			IProductVendorRepository productVendorRepository,
			IProductVendorModelValidator productVendorModelValidator
			) : base(logger,
			         context,
			         productVendorRepository,
			         productVendorModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6856a677f8ce4c720a5e2209392057cd</Hash>
</Codenesium>*/