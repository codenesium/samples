using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>e5292bb542da4866e7d35bcfd685d4f6</Hash>
</Codenesium>*/