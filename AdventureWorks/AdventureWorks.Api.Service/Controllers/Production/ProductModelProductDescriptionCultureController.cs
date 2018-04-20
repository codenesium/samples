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
	[Route("api/productModelProductDescriptionCultures")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductModelProductDescriptionCultureController: AbstractProductModelProductDescriptionCultureController
	{
		public ProductModelProductDescriptionCultureController(
			ServiceSettings settings,
			ILogger<ProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModelProductDescriptionCulture productModelProductDescriptionCultureManager
			)
			: base(settings,
			       logger,
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
    <Hash>ffb558b50d28ee5ae0ddc6eafeb1d741</Hash>
</Codenesium>*/