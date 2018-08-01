using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesOrderHeaderService : AbstractSalesOrderHeaderService, ISalesOrderHeaderService
	{
		public SalesOrderHeaderService(
			ILogger<ISalesOrderHeaderRepository> logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper bolsalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalsalesOrderHeaderMapper,
			IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalSalesOrderDetailMapper,
			IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper
			)
			: base(logger,
			       salesOrderHeaderRepository,
			       salesOrderHeaderModelValidator,
			       bolsalesOrderHeaderMapper,
			       dalsalesOrderHeaderMapper,
			       bolSalesOrderDetailMapper,
			       dalSalesOrderDetailMapper,
			       bolSalesOrderHeaderSalesReasonMapper,
			       dalSalesOrderHeaderSalesReasonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0c7815beb3915b5cca003bdca5c80d14</Hash>
</Codenesium>*/