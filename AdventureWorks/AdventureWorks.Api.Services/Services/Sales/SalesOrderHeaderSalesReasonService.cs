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
        public class SalesOrderHeaderSalesReasonService: AbstractSalesOrderHeaderSalesReasonService, ISalesOrderHeaderSalesReasonService
        {
                public SalesOrderHeaderSalesReasonService(
                        ILogger<SalesOrderHeaderSalesReasonRepository> logger,
                        ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
                        IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
                        IBOLSalesOrderHeaderSalesReasonMapper bolsalesOrderHeaderSalesReasonMapper,
                        IDALSalesOrderHeaderSalesReasonMapper dalsalesOrderHeaderSalesReasonMapper)
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
    <Hash>ad02c92f8bf262ff63e068420c75a936</Hash>
</Codenesium>*/