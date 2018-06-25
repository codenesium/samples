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
        public partial class SalesOrderDetailService : AbstractSalesOrderDetailService, ISalesOrderDetailService
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
    <Hash>d4a69c1ab90fc209cc9cf9a3273e9978</Hash>
</Codenesium>*/