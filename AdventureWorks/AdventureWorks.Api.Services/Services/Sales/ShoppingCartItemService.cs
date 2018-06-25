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
        public partial class ShoppingCartItemService : AbstractShoppingCartItemService, IShoppingCartItemService
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
    <Hash>4d3e0abd4fa8ebd5c21ab9d46deb83a7</Hash>
</Codenesium>*/