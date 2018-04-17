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
			ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator)
			: base(logger, salesOrderHeaderSalesReasonRepository, salesOrderHeaderSalesReasonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>21a245c35a2f44a716dfac7c8eca24a8</Hash>
</Codenesium>*/