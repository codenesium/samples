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
        public class ProductListPriceHistoryService : AbstractProductListPriceHistoryService, IProductListPriceHistoryService
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
                               dalproductListPriceHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5a7ed71f6c6c69f7e0014b8719801a24</Hash>
</Codenesium>*/