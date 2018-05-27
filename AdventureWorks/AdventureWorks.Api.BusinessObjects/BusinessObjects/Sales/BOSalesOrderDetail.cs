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
			IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
			IBOLSalesOrderDetailMapper salesOrderDetailMapper)
			: base(logger, salesOrderDetailRepository, salesOrderDetailModelValidator, salesOrderDetailMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>f49a52f273397ec5c12668ce40f1e354</Hash>
</Codenesium>*/