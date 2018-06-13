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
                        ILogger<SalesOrderDetailRepository> logger,
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
    <Hash>c73109c8533d314a9ffb6462dea3c564</Hash>
</Codenesium>*/