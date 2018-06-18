using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>f464466c456b425a02dfb8918f4cbda8</Hash>
</Codenesium>*/