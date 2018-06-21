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
        public class ProductCostHistoryService : AbstractProductCostHistoryService, IProductCostHistoryService
        {
                public ProductCostHistoryService(
                        ILogger<IProductCostHistoryRepository> logger,
                        IProductCostHistoryRepository productCostHistoryRepository,
                        IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
                        IBOLProductCostHistoryMapper bolproductCostHistoryMapper,
                        IDALProductCostHistoryMapper dalproductCostHistoryMapper
                        )
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
    <Hash>c621a1c0a4247fc00686404c1074d6df</Hash>
</Codenesium>*/