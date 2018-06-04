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
	public class SalesPersonQuotaHistoryService: AbstractSalesPersonQuotaHistoryService, ISalesPersonQuotaHistoryService
	{
		public SalesPersonQuotaHistoryService(
			ILogger<SalesPersonQuotaHistoryRepository> logger,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator,
			IBOLSalesPersonQuotaHistoryMapper BOLsalesPersonQuotaHistoryMapper,
			IDALSalesPersonQuotaHistoryMapper DALsalesPersonQuotaHistoryMapper)
			: base(logger, salesPersonQuotaHistoryRepository,
			       salesPersonQuotaHistoryModelValidator,
			       BOLsalesPersonQuotaHistoryMapper,
			       DALsalesPersonQuotaHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>569e82a8ab59c816c96fb61c9e49d5dd</Hash>
</Codenesium>*/