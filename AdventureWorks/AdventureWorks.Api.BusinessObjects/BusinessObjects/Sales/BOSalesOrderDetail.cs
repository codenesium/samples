using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOSalesOrderDetail: AbstractBOSalesOrderDetail, IBOSalesOrderDetail
	{
		public BOSalesOrderDetail(
			ILogger<SalesOrderDetailRepository> logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			IApiSalesOrderDetailModelValidator salesOrderDetailModelValidator)
			: base(logger, salesOrderDetailRepository, salesOrderDetailModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6295ef50cbdb523ccf8057b645a267d0</Hash>
</Codenesium>*/