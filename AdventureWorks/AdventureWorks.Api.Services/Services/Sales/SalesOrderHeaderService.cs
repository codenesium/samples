using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
			IDALSalesOrderDetailMapper dalSalesOrderDetailMapper)
			: base(logger,
			       salesOrderHeaderRepository,
			       salesOrderHeaderModelValidator,
			       bolsalesOrderHeaderMapper,
			       dalsalesOrderHeaderMapper,
			       bolSalesOrderDetailMapper,
			       dalSalesOrderDetailMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e2560f9d083922ac2889318aebe0fb04</Hash>
</Codenesium>*/