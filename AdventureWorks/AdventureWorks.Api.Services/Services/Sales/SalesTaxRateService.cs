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
        public class SalesTaxRateService : AbstractSalesTaxRateService, ISalesTaxRateService
        {
                public SalesTaxRateService(
                        ILogger<ISalesTaxRateRepository> logger,
                        ISalesTaxRateRepository salesTaxRateRepository,
                        IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
                        IBOLSalesTaxRateMapper bolsalesTaxRateMapper,
                        IDALSalesTaxRateMapper dalsalesTaxRateMapper
                        )
                        : base(logger,
                               salesTaxRateRepository,
                               salesTaxRateModelValidator,
                               bolsalesTaxRateMapper,
                               dalsalesTaxRateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>22aa23fda6209184690e48252e2ec9cd</Hash>
</Codenesium>*/