using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Web
{
	[Route("api/sales")]
	[ApiVersion("1.0")]
	public class SaleController: AbstractSaleController
	{
		public SaleController(
			ServiceSettings settings,
			ILogger<SaleController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISaleService saleService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       saleService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a8f09d7874a13036641944bb7a23b95c</Hash>
</Codenesium>*/