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
        public class SalesOrderHeaderService : AbstractSalesOrderHeaderService, ISalesOrderHeaderService
        {
                public SalesOrderHeaderService(
                        ILogger<ISalesOrderHeaderRepository> logger,
                        ISalesOrderHeaderRepository salesOrderHeaderRepository,
                        IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
                        IBOLSalesOrderHeaderMapper bolsalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalsalesOrderHeaderMapper,
                        IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
                        IDALSalesOrderDetailMapper dalSalesOrderDetailMapper,
                        IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
                        IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper
                        )
                        : base(logger,
                               salesOrderHeaderRepository,
                               salesOrderHeaderModelValidator,
                               bolsalesOrderHeaderMapper,
                               dalsalesOrderHeaderMapper,
                               bolSalesOrderDetailMapper,
                               dalSalesOrderDetailMapper,
                               bolSalesOrderHeaderSalesReasonMapper,
                               dalSalesOrderHeaderSalesReasonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>25a83c9504e63b6b28697e2f5a8c595c</Hash>
</Codenesium>*/