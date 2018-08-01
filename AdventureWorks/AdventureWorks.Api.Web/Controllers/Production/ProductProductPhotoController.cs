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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productProductPhotoes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductProductPhotoController : AbstractProductProductPhotoController
	{
		public ProductProductPhotoController(
			ApiSettings settings,
			ILogger<ProductProductPhotoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductProductPhotoService productProductPhotoService,
			IApiProductProductPhotoModelMapper productProductPhotoModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productProductPhotoService,
			       productProductPhotoModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ae6d6148c6d1979b7c6d73f353b1bfa1</Hash>
</Codenesium>*/