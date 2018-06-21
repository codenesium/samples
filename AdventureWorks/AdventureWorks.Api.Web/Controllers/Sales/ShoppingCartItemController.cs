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
        [ApiVersion("1.0")]
        public class ShoppingCartItemController : AbstractShoppingCartItemController
        {
                public ShoppingCartItemController(
                        ApiSettings settings,
                        ILogger<ShoppingCartItemController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IShoppingCartItemService shoppingCartItemService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               shoppingCartItemService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1355ea1e49db66230b74ec1dcd5305b6</Hash>
</Codenesium>*/