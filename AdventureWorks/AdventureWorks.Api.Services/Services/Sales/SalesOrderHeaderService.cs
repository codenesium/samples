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
	public class SalesOrderHeaderService: AbstractSalesOrderHeaderService, ISalesOrderHeaderService
	{
		public SalesOrderHeaderService(
			ILogger<SalesOrderHeaderRepository> logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper BOLsalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper DALsalesOrderHeaderMapper)
			: base(logger, salesOrderHeaderRepository,
			       salesOrderHeaderModelValidator,
			       BOLsalesOrderHeaderMapper,
			       DALsalesOrderHeaderMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>968d39218fb4a709255372eb2c8139f7</Hash>
</Codenesium>*/