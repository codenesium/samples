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
			IDALSalesPersonQuotaHistoryMapper dalsalesPersonQuotaHistoryMapper
			)
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
    <Hash>aa0a0a74cd8f7fdda342c44599cfa8a4</Hash>
</Codenesium>*/