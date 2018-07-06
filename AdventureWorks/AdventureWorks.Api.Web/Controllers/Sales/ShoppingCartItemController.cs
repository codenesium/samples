using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/shoppingCartItems")]
        [ApiController]
        [ApiVersion("1.0")]
        public class ShoppingCartItemController : AbstractShoppingCartItemController
        {
                public ShoppingCartItemController(
                        ApiSettings settings,
                        ILogger<ShoppingCartItemController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IShoppingCartItemService shoppingCartItemService,
                        IApiShoppingCartItemModelMapper shoppingCartItemModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               shoppingCartItemService,
                               shoppingCartItemModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>85fce16fbf5a08210fd23244ed168292</Hash>
</Codenesium>*/