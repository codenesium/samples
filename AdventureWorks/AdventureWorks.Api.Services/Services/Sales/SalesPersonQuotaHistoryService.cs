using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class SalesPersonQuotaHistoryService : AbstractSalesPersonQuotaHistoryService, ISalesPersonQuotaHistoryService
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
    <Hash>7d250cfb370cca7f22878a6168512b26</Hash>
</Codenesium>*/