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
	public partial class SalesOrderHeaderSalesReasonService : AbstractSalesOrderHeaderSalesReasonService, ISalesOrderHeaderSalesReasonService
	{
		public SalesOrderHeaderSalesReasonService(
			ILogger<ISalesOrderHeaderSalesReasonRepository> logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
			IBOLSalesOrderHeaderSalesReasonMapper bolsalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper dalsalesOrderHeaderSalesReasonMapper
			)
			: base(logger,
			       salesOrderHeaderSalesReasonRepository,
			       salesOrderHeaderSalesReasonModelValidator,
			       bolsalesOrderHeaderSalesReasonMapper,
			       dalsalesOrderHeaderSalesReasonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>44c6934fbe8f389ba118e7851e8e2a20</Hash>
</Codenesium>*/