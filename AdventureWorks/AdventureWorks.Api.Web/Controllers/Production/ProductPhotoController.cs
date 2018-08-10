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
	[Route("api/productPhotoes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductPhotoController : AbstractProductPhotoController
	{
		public ProductPhotoController(
			ApiSettings settings,
			ILogger<ProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductPhotoService productPhotoService,
			IApiProductPhotoModelMapper productPhotoModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productPhotoService,
			       productPhotoModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2473a31bc2680992c1474bb0a69b199a</Hash>
</Codenesium>*/