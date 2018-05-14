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
	public class BOSalesPersonQuotaHistory: AbstractBOSalesPersonQuotaHistory, IBOSalesPersonQuotaHistory
	{
		public BOSalesPersonQuotaHistory(
			ILogger<SalesPersonQuotaHistoryRepository> logger,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			IApiSalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator)
			: base(logger, salesPersonQuotaHistoryRepository, salesPersonQuotaHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f9515228a422aa6994b2c0b1a4925ac9</Hash>
</Codenesium>*/