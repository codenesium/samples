using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/creditCards")]
        [ApiVersion("1.0")]
        public class CreditCardController: AbstractCreditCardController
        {
                public CreditCardController(
                        ServiceSettings settings,
                        ILogger<CreditCardController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICreditCardService creditCardService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               creditCardService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>700d1b5fd67a24c65149103f55f2ebad</Hash>
</Codenesium>*/