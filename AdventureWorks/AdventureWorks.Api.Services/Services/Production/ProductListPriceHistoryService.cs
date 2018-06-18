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
        public class ProductListPriceHistoryService: AbstractProductListPriceHistoryService, IProductListPriceHistoryService
        {
                public ProductListPriceHistoryService(
                        ILogger<IProductListPriceHistoryRepository> logger,
                        IProductListPriceHistoryRepository productListPriceHistoryRepository,
                        IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
                        IBOLProductListPriceHistoryMapper bolproductListPriceHistoryMapper,
                        IDALProductListPriceHistoryMapper dalproductListPriceHistoryMapper

                        )
                        : base(logger,
                               productListPriceHistoryRepository,
                               productListPriceHistoryModelValidator,
                               bolproductListPriceHistoryMapper,
                               dalproductListPriceHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>38de349b6bd9bf5d6a749d3b7f10c795</Hash>
</Codenesium>*/