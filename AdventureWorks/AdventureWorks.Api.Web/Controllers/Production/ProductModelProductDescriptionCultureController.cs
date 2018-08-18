using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	[Route("api/productModelProductDescriptionCultures")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductModelProductDescriptionCultureController : AbstractProductModelProductDescriptionCultureController
	{
		public ProductModelProductDescriptionCultureController(
			ApiSettings settings,
			ILogger<ProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelProductDescriptionCultureService productModelProductDescriptionCultureService,
			IApiProductModelProductDescriptionCultureModelMapper productModelProductDescriptionCultureModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productModelProductDescriptionCultureService,
			       productModelProductDescriptionCultureModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>54bbbbae75ae52740a49319ff38765ad</Hash>
</Codenesium>*/