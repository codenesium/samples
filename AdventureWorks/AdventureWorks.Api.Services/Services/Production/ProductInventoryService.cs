using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class ProductInventoryService : AbstractProductInventoryService, IProductInventoryService
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
    <Hash>5c41fbe58d9c6077931042754cf03ab0</Hash>
</Codenesium>*/