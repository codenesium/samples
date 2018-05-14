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
			IApiSalesOrderHeaderModelValidator salesOrderHeaderModelValidator)
			: base(logger, salesOrderHeaderRepository, salesOrderHeaderModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>5628d54922773c2ab8bf123cf1cfe3d1</Hash>
</Codenesium>*/