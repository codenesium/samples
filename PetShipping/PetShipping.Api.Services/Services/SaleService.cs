using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class SaleService: AbstractSaleService, ISaleService
        {
                public SaleService(
                        ILogger<ISaleRepository> logger,
                        ISaleRepository saleRepository,
                        IApiSaleRequestModelValidator saleModelValidator,
                        IBOLSaleMapper bolsaleMapper,
                        IDALSaleMapper dalsaleMapper

                        )
                        : base(logger,
                               saleRepository,
                               saleModelValidator,
                               bolsaleMapper,
                               dalsaleMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>9840f6603424141f58852621d0345319</Hash>
</Codenesium>*/