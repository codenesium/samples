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
    <Hash>860e44c77892cebe1521948f29201d5f</Hash>
</Codenesium>*/