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
	[Route("api/salesOrderDetails")]
	public class SalesOrderDetailsController: AbstractSalesOrderDetailsController
	{
		public SalesOrderDetailsController(
			ILogger<SalesOrderDetailsController> logger,
			ApplicationContext context,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			ISalesOrderDetailModelValidator salesOrderDetailModelValidator
			) : base(logger,
			         context,
			         salesOrderDetailRepository,
			         salesOrderDetailModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7f82a05422b8f74c4515c098bd947ded</Hash>
</Codenesium>*/