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
			IApiSalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator)
			: base(logger, salesOrderHeaderSalesReasonRepository, salesOrderHeaderSalesReasonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a8406daf7e3d931b4ac96141beb12809</Hash>
</Codenesium>*/