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
        public partial class SalesOrderHeaderSalesReasonService : AbstractSalesOrderHeaderSalesReasonService, ISalesOrderHeaderSalesReasonService
        {
                public SalesOrderHeaderSalesReasonService(
                        ILogger<ISalesOrderHeaderSalesReasonRepository> logger,
                        ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
                        IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
                        IBOLSalesOrderHeaderSalesReasonMapper bolsalesOrderHeaderSalesReasonMapper,
                        IDALSalesOrderHeaderSalesReasonMapper dalsalesOrderHeaderSalesReasonMapper
                        )
                        : base(logger,
                               salesOrderHeaderSalesReasonRepository,
                               salesOrderHeaderSalesReasonModelValidator,
                               bolsalesOrderHeaderSalesReasonMapper,
                               dalsalesOrderHeaderSalesReasonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f8dae2d83d0f17c0f6ee065ad1aacbf0</Hash>
</Codenesium>*/