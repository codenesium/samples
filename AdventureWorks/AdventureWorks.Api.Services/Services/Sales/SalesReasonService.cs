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
        public partial class SalesReasonService : AbstractSalesReasonService, ISalesReasonService
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
    <Hash>1f445603380b5ed095bb6d010431a6a5</Hash>
</Codenesium>*/