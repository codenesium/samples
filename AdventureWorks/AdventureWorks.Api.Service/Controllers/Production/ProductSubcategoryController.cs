using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productSubcategories")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductSubcategoryController: AbstractProductSubcategoryController
	{
		public ProductSubcategoryController(
			ServiceSettings settings,
			ILogger<ProductSubcategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductSubcategory productSubcategoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productSubcategoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>466fee6e7709f02385553761163f23b5</Hash>
</Codenesium>*/