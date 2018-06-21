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
        public class SalesTerritoryHistoryService : AbstractSalesTerritoryHistoryService, ISalesTerritoryHistoryService
        {
                public SalesTerritoryHistoryService(
                        ILogger<ISalesTerritoryHistoryRepository> logger,
                        ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
                        IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
                        IBOLSalesTerritoryHistoryMapper bolsalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalsalesTerritoryHistoryMapper
                        )
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
    <Hash>3f6cc7a0f4e5229d6a15916263adacb3</Hash>
</Codenesium>*/