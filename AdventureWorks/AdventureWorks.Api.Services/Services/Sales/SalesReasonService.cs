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
                        IDALSalesReasonMapper dalsalesReasonMapper)
                        : base(logger,
                               salesReasonRepository,
                               salesReasonModelValidator,
                               bolsalesReasonMapper,
                               dalsalesReasonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>061ec947820a9112dfdb0bef5d46041b</Hash>
</Codenesium>*/