using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ShoppingCartItemRepository : AbstractShoppingCartItemRepository, IShoppingCartItemRepository
        {
                public ShoppingCartItemRepository(
                        ILogger<ShoppingCartItemRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b55e144951617d9ec66825e6f39a7689</Hash>
</Codenesium>*/