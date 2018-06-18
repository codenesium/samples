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
        public class ProductInventoryService: AbstractProductInventoryService, IProductInventoryService
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
                               dalproductInventoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>fd8a9527a3be5394eb4ff9e14d517732</Hash>
</Codenesium>*/