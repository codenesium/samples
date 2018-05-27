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
	public class BOSalesOrderHeaderSalesReason: AbstractBOSalesOrderHeaderSalesReason, IBOSalesOrderHeaderSalesReason
	{
		public BOSalesOrderHeaderSalesReason(
			ILogger<SalesOrderHeaderSalesReasonRepository> logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
			IBOLSalesOrderHeaderSalesReasonMapper salesOrderHeaderSalesReasonMapper)
			: base(logger, salesOrderHeaderSalesReasonRepository, salesOrderHeaderSalesReasonModelValidator, salesOrderHeaderSalesReasonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0267dc609bc7d36862b82c7c914e171e</Hash>
</Codenesium>*/