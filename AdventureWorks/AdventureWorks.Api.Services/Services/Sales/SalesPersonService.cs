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
        public class SalesPersonService: AbstractSalesPersonService, ISalesPersonService
        {
                public SalesPersonService(
                        ILogger<SalesPersonRepository> logger,
                        ISalesPersonRepository salesPersonRepository,
                        IApiSalesPersonRequestModelValidator salesPersonModelValidator,
                        IBOLSalesPersonMapper bolsalesPersonMapper,
                        IDALSalesPersonMapper dalsalesPersonMapper)
                        : base(logger,
                               salesPersonRepository,
                               salesPersonModelValidator,
                               bolsalesPersonMapper,
                               dalsalesPersonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>51c9f57f68dece9e743c936ff151ba78</Hash>
</Codenesium>*/