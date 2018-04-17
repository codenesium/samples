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
			ISalesOrderDetailModelValidator salesOrderDetailModelValidator)
			: base(logger, salesOrderDetailRepository, salesOrderDetailModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>3aea865d66ce137e5df5afee9d90d7f4</Hash>
</Codenesium>*/