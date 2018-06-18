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
                        ILogger<ISalesReasonRepository> logger,
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
    <Hash>68472098b78570a81fc8b9acf0470cdb</Hash>
</Codenesium>*/