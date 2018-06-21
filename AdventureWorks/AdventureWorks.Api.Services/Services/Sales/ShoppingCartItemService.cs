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
        public class ShoppingCartItemService : AbstractShoppingCartItemService, IShoppingCartItemService
        {
                public ShoppingCartItemService(
                        ILogger<IShoppingCartItemRepository> logger,
                        IShoppingCartItemRepository shoppingCartItemRepository,
                        IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
                        IBOLShoppingCartItemMapper bolshoppingCartItemMapper,
                        IDALShoppingCartItemMapper dalshoppingCartItemMapper
                        )
                        : base(logger,
                               shoppingCartItemRepository,
                               shoppingCartItemModelValidator,
                               bolshoppingCartItemMapper,
                               dalshoppingCartItemMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9a07b71a7f268230410647aa824ac145</Hash>
</Codenesium>*/