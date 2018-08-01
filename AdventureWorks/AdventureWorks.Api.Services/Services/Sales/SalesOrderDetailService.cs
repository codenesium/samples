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
	public partial class SalesOrderDetailService : AbstractSalesOrderDetailService, ISalesOrderDetailService
	{
		public SalesOrderDetailService(
			ILogger<ISalesOrderDetailRepository> logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
			IBOLSalesOrderDetailMapper bolsalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalsalesOrderDetailMapper
			)
			: base(logger,
			       salesOrderDetailRepository,
			       salesOrderDetailModelValidator,
			       bolsalesOrderDetailMapper,
			       dalsalesOrderDetailMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bde20d63f00a8b9b4a702cc93c83218c</Hash>
</Codenesium>*/