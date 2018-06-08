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
        public class SpecialOfferProductService: AbstractSpecialOfferProductService, ISpecialOfferProductService
        {
                public SpecialOfferProductService(
                        ILogger<SpecialOfferProductRepository> logger,
                        ISpecialOfferProductRepository specialOfferProductRepository,
                        IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
                        IBOLSpecialOfferProductMapper bolspecialOfferProductMapper,
                        IDALSpecialOfferProductMapper dalspecialOfferProductMapper)
                        : base(logger,
                               specialOfferProductRepository,
                               specialOfferProductModelValidator,
                               bolspecialOfferProductMapper,
                               dalspecialOfferProductMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7cb65a10d6d4238d432d3bee361b5daa</Hash>
</Codenesium>*/