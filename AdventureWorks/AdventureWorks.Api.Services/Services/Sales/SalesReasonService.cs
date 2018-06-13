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
        public class SalesReasonService: AbstractSalesReasonService, ISalesReasonService
        {
                public SalesReasonService(
                        ILogger<SalesReasonRepository> logger,
                        ISalesReasonRepository salesReasonRepository,
                        IApiSalesReasonRequestModelValidator salesReasonModelValidator,
                        IBOLSalesReasonMapper bolsalesReasonMapper,
                        IDALSalesReasonMapper dalsalesReasonMapper
                        ,
                        IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
                        IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper

                        )
                        : base(logger,
                               salesReasonRepository,
                               salesReasonModelValidator,
                               bolsalesReasonMapper,
                               dalsalesReasonMapper
                               ,
                               bolSalesOrderHeaderSalesReasonMapper,
                               dalSalesOrderHeaderSalesReasonMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>75bff07d60f48292c70c1694fae2d306</Hash>
</Codenesium>*/