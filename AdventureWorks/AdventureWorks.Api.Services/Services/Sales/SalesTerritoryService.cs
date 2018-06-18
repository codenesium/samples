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
        public class SalesTerritoryService: AbstractSalesTerritoryService, ISalesTerritoryService
        {
                public SalesTerritoryService(
                        ILogger<ISalesTerritoryRepository> logger,
                        ISalesTerritoryRepository salesTerritoryRepository,
                        IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
                        IBOLSalesTerritoryMapper bolsalesTerritoryMapper,
                        IDALSalesTerritoryMapper dalsalesTerritoryMapper
                        ,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper
                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
                        ,
                        IBOLSalesPersonMapper bolSalesPersonMapper,
                        IDALSalesPersonMapper dalSalesPersonMapper
                        ,
                        IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper

                        )
                        : base(logger,
                               salesTerritoryRepository,
                               salesTerritoryModelValidator,
                               bolsalesTerritoryMapper,
                               dalsalesTerritoryMapper
                               ,
                               bolCustomerMapper,
                               dalCustomerMapper
                               ,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper
                               ,
                               bolSalesPersonMapper,
                               dalSalesPersonMapper
                               ,
                               bolSalesTerritoryHistoryMapper,
                               dalSalesTerritoryHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>21b69c817b3ad40ec34a262fb3438f04</Hash>
</Codenesium>*/