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
    <Hash>b9edf4cd2593fb024afe373110ab5ece</Hash>
</Codenesium>*/