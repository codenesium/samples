using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productModelProductDescriptionCultures")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductModelProductDescriptionCultureFilter))]
	public class ProductModelProductDescriptionCultureController: AbstractProductModelProductDescriptionCultureController
	{
		public ProductModelProductDescriptionCultureController(
			ILogger<ProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productModelProductDescriptionCultureRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>07ace72a592dbdad46bbcbef0921c7b2</Hash>
</Codenesium>*/