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
        public class SalesTerritoryService : AbstractSalesTerritoryService, ISalesTerritoryService
        {
                public SalesTerritoryService(
                        ILogger<ISalesTerritoryRepository> logger,
                        ISalesTerritoryRepository salesTerritoryRepository,
                        IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
                        IBOLSalesTerritoryMapper bolsalesTerritoryMapper,
                        IDALSalesTerritoryMapper dalsalesTerritoryMapper,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
                        IBOLSalesPersonMapper bolSalesPersonMapper,
                        IDALSalesPersonMapper dalSalesPersonMapper,
                        IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper
                        )
                        : base(logger,
                               salesTerritoryRepository,
                               salesTerritoryModelValidator,
                               bolsalesTerritoryMapper,
                               dalsalesTerritoryMapper,
                               bolCustomerMapper,
                               dalCustomerMapper,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper,
                               bolSalesPersonMapper,
                               dalSalesPersonMapper,
                               bolSalesTerritoryHistoryMapper,
                               dalSalesTerritoryHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2695915f0f62bd0e3720391501ff5206</Hash>
</Codenesium>*/