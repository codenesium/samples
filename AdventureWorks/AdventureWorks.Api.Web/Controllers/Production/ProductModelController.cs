using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productModels")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class ProductModelController : AbstractProductModelController
	{
		public ProductModelController(
			ApiSettings settings,
			ILogger<ProductModelController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelService productModelService,
			IApiProductModelServerModelMapper productModelModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productModelService,
			       productModelModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>da1543eeb709ed92e4cfdf7d8cf696eb</Hash>
</Codenesium>*/