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
        public partial class ProductInventoryService : AbstractProductInventoryService, IProductInventoryService
        {
                public ProductInventoryService(
                        ILogger<IProductInventoryRepository> logger,
                        IProductInventoryRepository productInventoryRepository,
                        IApiProductInventoryRequestModelValidator productInventoryModelValidator,
                        IBOLProductInventoryMapper bolproductInventoryMapper,
                        IDALProductInventoryMapper dalproductInventoryMapper
                        )
                        : base(logger,
                               productInventoryRepository,
                               productInventoryModelValidator,
                               bolproductInventoryMapper,
                               dalproductInventoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8fba92064685770f9c27ac9edd476cdb</Hash>
</Codenesium>*/