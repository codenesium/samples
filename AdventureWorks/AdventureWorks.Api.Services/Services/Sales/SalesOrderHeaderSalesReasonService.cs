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
                               dalsalesOrderHeaderSalesReasonMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>fab0ea20f3be29a49a0673ee154920b5</Hash>
</Codenesium>*/