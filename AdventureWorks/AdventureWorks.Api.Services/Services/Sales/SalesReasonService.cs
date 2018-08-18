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
	public partial class SalesReasonService : AbstractSalesReasonService, ISalesReasonService
	{
		public SalesReasonService(
			ILogger<ISalesReasonRepository> logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper bolsalesReasonMapper,
			IDALSalesReasonMapper dalsalesReasonMapper,
			IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper
			)
			: base(logger,
			       salesReasonRepository,
			       salesReasonModelValidator,
			       bolsalesReasonMapper,
			       dalsalesReasonMapper,
			       bolSalesOrderHeaderSalesReasonMapper,
			       dalSalesOrderHeaderSalesReasonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b17a215371cefc95557f4fad6c8f5431</Hash>
</Codenesium>*/