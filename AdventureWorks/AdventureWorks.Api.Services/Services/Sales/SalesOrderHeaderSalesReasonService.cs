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
	public class SalesOrderHeaderSalesReasonService: AbstractSalesOrderHeaderSalesReasonService, ISalesOrderHeaderSalesReasonService
	{
		public SalesOrderHeaderSalesReasonService(
			ILogger<SalesOrderHeaderSalesReasonRepository> logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
			IBOLSalesOrderHeaderSalesReasonMapper BOLsalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper DALsalesOrderHeaderSalesReasonMapper)
			: base(logger, salesOrderHeaderSalesReasonRepository,
			       salesOrderHeaderSalesReasonModelValidator,
			       BOLsalesOrderHeaderSalesReasonMapper,
			       DALsalesOrderHeaderSalesReasonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e3d08b82773e2100fa6e7271ebbbdb03</Hash>
</Codenesium>*/