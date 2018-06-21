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
    <Hash>791ececcff9899608417c268cae83582</Hash>
</Codenesium>*/