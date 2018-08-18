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
	[Route("api/productDescriptions")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductDescriptionController : AbstractProductDescriptionController
	{
		public ProductDescriptionController(
			ApiSettings settings,
			ILogger<ProductDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDescriptionService productDescriptionService,
			IApiProductDescriptionModelMapper productDescriptionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productDescriptionService,
			       productDescriptionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0ae70c28fe1a753151f98076a2383c3f</Hash>
</Codenesium>*/