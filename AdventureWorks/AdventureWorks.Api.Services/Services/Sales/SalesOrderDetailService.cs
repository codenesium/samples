using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class SalesOrderDetailService : AbstractSalesOrderDetailService, ISalesOrderDetailService
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
                               dalsalesOrderDetailMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8c96b9defba05645782642318f9de934</Hash>
</Codenesium>*/