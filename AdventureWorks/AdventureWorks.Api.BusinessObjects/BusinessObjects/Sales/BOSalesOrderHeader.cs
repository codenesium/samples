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
			IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper salesOrderHeaderMapper)
			: base(logger, salesOrderHeaderRepository, salesOrderHeaderModelValidator, salesOrderHeaderMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>1c5cd18dbe92ab498dfee19ea6b6008d</Hash>
</Codenesium>*/