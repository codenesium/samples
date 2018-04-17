using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productSubcategories")]
	[ApiVersion("1.0")]
	public class ProductSubcategoryController: AbstractProductSubcategoryController
	{
		public ProductSubcategoryController(
			ILogger<ProductSubcategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductSubcategory productSubcategoryManager
			)
			: base(logger,
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
    <Hash>eaa88834aba70bc149fae7177f47a269</Hash>
</Codenesium>*/