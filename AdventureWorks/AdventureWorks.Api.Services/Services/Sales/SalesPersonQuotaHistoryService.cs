using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesPersonQuotaHistoryService : AbstractSalesPersonQuotaHistoryService, ISalesPersonQuotaHistoryService
	{
		public SalesPersonQuotaHistoryService(
			ILogger<ISalesPersonQuotaHistoryRepository> logger,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator,
			IBOLSalesPersonQuotaHistoryMapper bolsalesPersonQuotaHistoryMapper,
			IDALSalesPersonQuotaHistoryMapper dalsalesPersonQuotaHistoryMapper)
			: base(logger,
			       salesPersonQuotaHistoryRepository,
			       salesPersonQuotaHistoryModelValidator,
			       bolsalesPersonQuotaHistoryMapper,
			       dalsalesPersonQuotaHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e89605154fc81bad9c9fc23df8fa10bd</Hash>
</Codenesium>*/