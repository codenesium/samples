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
        public partial class SalesOrderHeaderService : AbstractSalesOrderHeaderService, ISalesOrderHeaderService
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
    <Hash>b3c33ffc4df23e14e7703f9b786f0c05</Hash>
</Codenesium>*/