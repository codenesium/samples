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
                        ILogger<ProductInventoryRepository> logger,
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
    <Hash>00208f044146dbc3a7f47db6ca356b10</Hash>
</Codenesium>*/