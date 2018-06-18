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
        public class SalesOrderDetailService: AbstractSalesOrderDetailService, ISalesOrderDetailService
        {
                public SalesOrderDetailService(
                        ILogger<ISalesOrderDetailRepository> logger,
                        ISalesOrderDetailRepository salesOrderDetailRepository,
                        IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
                        IBOLSalesOrderDetailMapper bolsalesOrderDetailMapper,
                        IDALSalesOrderDetailMapper dalsalesOrderDetailMapper

                        )
                        : base(logger,
                               salesOrderDetailRepository,
                               salesOrderDetailModelValidator,
                               bolsalesOrderDetailMapper,
                               dalsalesOrderDetailMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>11d68fa0f010e8af1d21a1b8fcad0a5e</Hash>
</Codenesium>*/