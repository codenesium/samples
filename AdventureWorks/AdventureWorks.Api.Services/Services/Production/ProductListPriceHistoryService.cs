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
                        ILogger<ProductListPriceHistoryRepository> logger,
                        IProductListPriceHistoryRepository productListPriceHistoryRepository,
                        IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
                        IBOLProductListPriceHistoryMapper bolproductListPriceHistoryMapper,
                        IDALProductListPriceHistoryMapper dalproductListPriceHistoryMapper)
                        : base(logger,
                               productListPriceHistoryRepository,
                               productListPriceHistoryModelValidator,
                               bolproductListPriceHistoryMapper,
                               dalproductListPriceHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ac6fe0c541653fffd129d720b5037ef1</Hash>
</Codenesium>*/