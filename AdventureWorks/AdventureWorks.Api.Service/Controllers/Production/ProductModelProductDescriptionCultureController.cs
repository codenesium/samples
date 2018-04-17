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
	[Route("api/productModelProductDescriptionCultures")]
	[ApiVersion("1.0")]
	public class ProductModelProductDescriptionCultureController: AbstractProductModelProductDescriptionCultureController
	{
		public ProductModelProductDescriptionCultureController(
			ILogger<ProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModelProductDescriptionCulture productModelProductDescriptionCultureManager
			)
			: base(logger,
			       transactionCoordinator,
			       productModelProductDescriptionCultureManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cef6a605eb035b2c9a98d20b281affd4</Hash>
</Codenesium>*/