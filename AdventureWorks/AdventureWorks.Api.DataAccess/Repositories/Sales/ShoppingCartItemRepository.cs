using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>522318c741a6f3c7c800e05e579edf1b</Hash>
</Codenesium>*/