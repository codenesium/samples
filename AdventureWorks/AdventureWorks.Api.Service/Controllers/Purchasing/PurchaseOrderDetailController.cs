using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/purchaseOrderDetails")]
	public class PurchaseOrderDetailsController: AbstractPurchaseOrderDetailsController
	{
		public PurchaseOrderDetailsController(
			ILogger<PurchaseOrderDetailsController> logger,
			ApplicationContext context,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator
			) : base(logger,
			         context,
			         purchaseOrderDetailRepository,
			         purchaseOrderDetailModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>36ce087cc5b0d29f739df581b3daafec</Hash>
</Codenesium>*/