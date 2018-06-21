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
        public class SalesOrderHeaderSalesReasonService : AbstractSalesOrderHeaderSalesReasonService, ISalesOrderHeaderSalesReasonService
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
    <Hash>5bd34729d026b139c5cab79e544a1426</Hash>
</Codenesium>*/