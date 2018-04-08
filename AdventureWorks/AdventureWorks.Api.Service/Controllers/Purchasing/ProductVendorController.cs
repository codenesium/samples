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
			ITransactionCoordinator transactionCoordinator,
			IProductVendorRepository productVendorRepository,
			IProductVendorModelValidator productVendorModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productVendorRepository,
			         productVendorModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7fbc67f816343b68bd2ea1637045101c</Hash>
</Codenesium>*/