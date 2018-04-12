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
	public class ProductModelProductDescriptionCultureController: AbstractProductModelProductDescriptionCultureController
	{
		public ProductModelProductDescriptionCultureController(
			ILogger<ProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productModelProductDescriptionCultureRepository,
			       productModelProductDescriptionCultureModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>44d741c923e4a3e44e4d5709e73ce3b3</Hash>
</Codenesium>*/