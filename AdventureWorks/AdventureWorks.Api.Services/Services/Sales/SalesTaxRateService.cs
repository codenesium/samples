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
                               dalsalesTaxRateMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>22e7bb1025b1a279f0154a52247b8957</Hash>
</Codenesium>*/