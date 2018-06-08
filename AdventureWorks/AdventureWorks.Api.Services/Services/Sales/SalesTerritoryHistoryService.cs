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
        public class SalesTerritoryHistoryService: AbstractSalesTerritoryHistoryService, ISalesTerritoryHistoryService
        {
                public SalesTerritoryHistoryService(
                        ILogger<SalesTerritoryHistoryRepository> logger,
                        ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
                        IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
                        IBOLSalesTerritoryHistoryMapper bolsalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalsalesTerritoryHistoryMapper)
                        : base(logger,
                               salesTerritoryHistoryRepository,
                               salesTerritoryHistoryModelValidator,
                               bolsalesTerritoryHistoryMapper,
                               dalsalesTerritoryHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4df040d9b340bf87eea48e2ff76100cb</Hash>
</Codenesium>*/