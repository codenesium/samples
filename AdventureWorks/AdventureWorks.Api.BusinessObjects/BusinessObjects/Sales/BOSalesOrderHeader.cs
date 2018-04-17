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
	public class BOSalesOrderHeader: AbstractBOSalesOrderHeader, IBOSalesOrderHeader
	{
		public BOSalesOrderHeader(
			ILogger<SalesOrderHeaderRepository> logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator)
			: base(logger, salesOrderHeaderRepository, salesOrderHeaderModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f406b02c2aaca8ea44f45b4070645cfb</Hash>
</Codenesium>*/