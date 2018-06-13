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
                        IDALSalesTerritoryHistoryMapper dalsalesTerritoryHistoryMapper

                        )
                        : base(logger,
                               salesTerritoryHistoryRepository,
                               salesTerritoryHistoryModelValidator,
                               bolsalesTerritoryHistoryMapper,
                               dalsalesTerritoryHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b6c24c4c04af1c46e35fc6407f9ee3ce</Hash>
</Codenesium>*/