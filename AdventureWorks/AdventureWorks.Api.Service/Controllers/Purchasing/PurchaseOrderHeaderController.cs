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
	[Route("api/purchaseOrderHeaders")]
	public class PurchaseOrderHeadersController: AbstractPurchaseOrderHeadersController
	{
		public PurchaseOrderHeadersController(
			ILogger<PurchaseOrderHeadersController> logger,
			ApplicationContext context,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator
			) : base(logger,
			         context,
			         purchaseOrderHeaderRepository,
			         purchaseOrderHeaderModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>efddc2fce9004da98f1e55b5d754c78e</Hash>
</Codenesium>*/