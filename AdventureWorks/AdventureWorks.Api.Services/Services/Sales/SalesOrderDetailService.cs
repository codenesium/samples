using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class SalesOrderDetailService: AbstractSalesOrderDetailService, ISalesOrderDetailService
	{
		public SalesOrderDetailService(
			ILogger<SalesOrderDetailRepository> logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
			IBOLSalesOrderDetailMapper BOLsalesOrderDetailMapper,
			IDALSalesOrderDetailMapper DALsalesOrderDetailMapper)
			: base(logger, salesOrderDetailRepository,
			       salesOrderDetailModelValidator,
			       BOLsalesOrderDetailMapper,
			       DALsalesOrderDetailMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>20253bb0f6ae130e8ebbd77264267cc4</Hash>
</Codenesium>*/