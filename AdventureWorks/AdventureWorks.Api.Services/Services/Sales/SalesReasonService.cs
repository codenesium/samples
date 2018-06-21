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
        public class SalesReasonService : AbstractSalesReasonService, ISalesReasonService
        {
                public SalesReasonService(
                        ILogger<ISalesReasonRepository> logger,
                        ISalesReasonRepository salesReasonRepository,
                        IApiSalesReasonRequestModelValidator salesReasonModelValidator,
                        IBOLSalesReasonMapper bolsalesReasonMapper,
                        IDALSalesReasonMapper dalsalesReasonMapper,
                        IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
                        IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper
                        )
                        : base(logger,
                               salesReasonRepository,
                               salesReasonModelValidator,
                               bolsalesReasonMapper,
                               dalsalesReasonMapper,
                               bolSalesOrderHeaderSalesReasonMapper,
                               dalSalesOrderHeaderSalesReasonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a7fa05bac05db7a9ae59188548a239ef</Hash>
</Codenesium>*/