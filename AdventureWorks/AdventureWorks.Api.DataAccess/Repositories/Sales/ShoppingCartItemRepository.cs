using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ShoppingCartItemRepository: AbstractShoppingCartItemRepository, IShoppingCartItemRepository
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
    <Hash>d0af2bc78012a94d2b9b3a378713ae0f</Hash>
</Codenesium>*/