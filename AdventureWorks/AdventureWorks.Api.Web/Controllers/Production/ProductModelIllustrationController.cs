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
	[Route("api/productModelIllustrations")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class ProductModelIllustrationController : AbstractProductModelIllustrationController
	{
		public ProductModelIllustrationController(
			ApiSettings settings,
			ILogger<ProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelIllustrationService productModelIllustrationService,
			IApiProductModelIllustrationModelMapper productModelIllustrationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productModelIllustrationService,
			       productModelIllustrationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2dc6a8382502525aee017638648af0e8</Hash>
</Codenesium>*/