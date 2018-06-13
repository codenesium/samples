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
        public class SalesPersonService: AbstractSalesPersonService, ISalesPersonService
        {
                public SalesPersonService(
                        ILogger<SalesPersonRepository> logger,
                        ISalesPersonRepository salesPersonRepository,
                        IApiSalesPersonRequestModelValidator salesPersonModelValidator,
                        IBOLSalesPersonMapper bolsalesPersonMapper,
                        IDALSalesPersonMapper dalsalesPersonMapper
                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
                        ,
                        IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper,
                        IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper
                        ,
                        IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper
                        ,
                        IBOLStoreMapper bolStoreMapper,
                        IDALStoreMapper dalStoreMapper

                        )
                        : base(logger,
                               salesPersonRepository,
                               salesPersonModelValidator,
                               bolsalesPersonMapper,
                               dalsalesPersonMapper
                               ,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper
                               ,
                               bolSalesPersonQuotaHistoryMapper,
                               dalSalesPersonQuotaHistoryMapper
                               ,
                               bolSalesTerritoryHistoryMapper,
                               dalSalesTerritoryHistoryMapper
                               ,
                               bolStoreMapper,
                               dalStoreMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>036f1ca6933275c4023dd100a873ec66</Hash>
</Codenesium>*/