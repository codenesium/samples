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
        public class ProductCostHistoryService: AbstractProductCostHistoryService, IProductCostHistoryService
        {
                public ProductCostHistoryService(
                        ILogger<ProductCostHistoryRepository> logger,
                        IProductCostHistoryRepository productCostHistoryRepository,
                        IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
                        IBOLProductCostHistoryMapper bolproductCostHistoryMapper,
                        IDALProductCostHistoryMapper dalproductCostHistoryMapper)
                        : base(logger,
                               productCostHistoryRepository,
                               productCostHistoryModelValidator,
                               bolproductCostHistoryMapper,
                               dalproductCostHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2a6907454988cef4d0121d0f9e2d77cd</Hash>
</Codenesium>*/