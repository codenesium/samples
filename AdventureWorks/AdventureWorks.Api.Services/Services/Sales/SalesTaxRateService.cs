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
        public partial class SalesTaxRateService : AbstractSalesTaxRateService, ISalesTaxRateService
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
    <Hash>0e4576cf4a7eb0038bace5e580b430f1</Hash>
</Codenesium>*/