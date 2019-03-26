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
			IApiProductProductPhotoServerModelMapper productProductPhotoModelMapper
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
    <Hash>3d3ccaa9253c62b040320502ab44ebb1</Hash>
</Codenesium>*/