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
        public class SalesOrderHeaderService: AbstractSalesOrderHeaderService, ISalesOrderHeaderService
        {
                public SalesOrderHeaderService(
                        ILogger<SalesOrderHeaderRepository> logger,
                        ISalesOrderHeaderRepository salesOrderHeaderRepository,
                        IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
                        IBOLSalesOrderHeaderMapper bolsalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalsalesOrderHeaderMapper)
                        : base(logger,
                               salesOrderHeaderRepository,
                               salesOrderHeaderModelValidator,
                               bolsalesOrderHeaderMapper,
                               dalsalesOrderHeaderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ee9184412f18e371a8e09e079465004a</Hash>
</Codenesium>*/