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
			IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator,
			IBOLSalesPersonQuotaHistoryMapper salesPersonQuotaHistoryMapper)
			: base(logger, salesPersonQuotaHistoryRepository, salesPersonQuotaHistoryModelValidator, salesPersonQuotaHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6be24737e79cbdf8db49c55b158aa3df</Hash>
</Codenesium>*/