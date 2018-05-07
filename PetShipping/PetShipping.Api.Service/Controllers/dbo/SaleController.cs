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
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/sales")]
	[ApiVersion("1.0")]
	public class SaleController: AbstractSaleController
	{
		public SaleController(
			ServiceSettings settings,
			ILogger<SaleController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSale saleManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       saleManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3c20de850b6d03bdd89182e5f21945a9</Hash>
</Codenesium>*/