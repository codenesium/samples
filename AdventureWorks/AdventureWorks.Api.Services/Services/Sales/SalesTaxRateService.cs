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
        public class SalesTaxRateService: AbstractSalesTaxRateService, ISalesTaxRateService
        {
                public SalesTaxRateService(
                        ILogger<SalesTaxRateRepository> logger,
                        ISalesTaxRateRepository salesTaxRateRepository,
                        IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
                        IBOLSalesTaxRateMapper bolsalesTaxRateMapper,
                        IDALSalesTaxRateMapper dalsalesTaxRateMapper)
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
    <Hash>4b7eb9b133457ec33117bea8442a735b</Hash>
</Codenesium>*/