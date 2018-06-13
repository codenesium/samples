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
        public class SalesOrderHeaderService: AbstractSalesOrderHeaderService, ISalesOrderHeaderService
        {
                public SalesOrderHeaderService(
                        ILogger<SalesOrderHeaderRepository> logger,
                        ISalesOrderHeaderRepository salesOrderHeaderRepository,
                        IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
                        IBOLSalesOrderHeaderMapper bolsalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalsalesOrderHeaderMapper
                        ,
                        IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
                        IDALSalesOrderDetailMapper dalSalesOrderDetailMapper
                        ,
                        IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
                        IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper

                        )
                        : base(logger,
                               salesOrderHeaderRepository,
                               salesOrderHeaderModelValidator,
                               bolsalesOrderHeaderMapper,
                               dalsalesOrderHeaderMapper
                               ,
                               bolSalesOrderDetailMapper,
                               dalSalesOrderDetailMapper
                               ,
                               bolSalesOrderHeaderSalesReasonMapper,
                               dalSalesOrderHeaderSalesReasonMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e27406bca862c5019fe037730523d7f3</Hash>
</Codenesium>*/