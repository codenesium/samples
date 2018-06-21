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
        public class SalesPersonService : AbstractSalesPersonService, ISalesPersonService
        {
                public SalesPersonService(
                        ILogger<ISalesPersonRepository> logger,
                        ISalesPersonRepository salesPersonRepository,
                        IApiSalesPersonRequestModelValidator salesPersonModelValidator,
                        IBOLSalesPersonMapper bolsalesPersonMapper,
                        IDALSalesPersonMapper dalsalesPersonMapper,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
                        IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper,
                        IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper,
                        IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper,
                        IBOLStoreMapper bolStoreMapper,
                        IDALStoreMapper dalStoreMapper
                        )
                        : base(logger,
                               salesPersonRepository,
                               salesPersonModelValidator,
                               bolsalesPersonMapper,
                               dalsalesPersonMapper,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper,
                               bolSalesPersonQuotaHistoryMapper,
                               dalSalesPersonQuotaHistoryMapper,
                               bolSalesTerritoryHistoryMapper,
                               dalSalesTerritoryHistoryMapper,
                               bolStoreMapper,
                               dalStoreMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0e47b11d91de79db4368b1f84d23a1f3</Hash>
</Codenesium>*/