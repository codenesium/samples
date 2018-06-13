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
        public class ShoppingCartItemService: AbstractShoppingCartItemService, IShoppingCartItemService
        {
                public ShoppingCartItemService(
                        ILogger<ShoppingCartItemRepository> logger,
                        IShoppingCartItemRepository shoppingCartItemRepository,
                        IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
                        IBOLShoppingCartItemMapper bolshoppingCartItemMapper,
                        IDALShoppingCartItemMapper dalshoppingCartItemMapper

                        )
                        : base(logger,
                               shoppingCartItemRepository,
                               shoppingCartItemModelValidator,
                               bolshoppingCartItemMapper,
                               dalshoppingCartItemMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>055e07377e4099aa2f28e62105e9915e</Hash>
</Codenesium>*/