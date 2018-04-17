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
			ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator)
			: base(logger, salesPersonQuotaHistoryRepository, salesPersonQuotaHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>56e66a832df2486af50a6e5d0ba76c40</Hash>
</Codenesium>*/