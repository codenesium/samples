using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ShoppingCartItemRepository : AbstractShoppingCartItemRepository, IShoppingCartItemRepository
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
    <Hash>3c146bda141dd1255d2760a89efa3a75</Hash>
</Codenesium>*/