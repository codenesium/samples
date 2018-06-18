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
                               dalsalesTerritoryHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2b8027f63647ef7c982bdfe1128236be</Hash>
</Codenesium>*/