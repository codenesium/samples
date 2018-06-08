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
    <Hash>4136e2d7bd097ee45e7c0202343f45d3</Hash>
</Codenesium>*/