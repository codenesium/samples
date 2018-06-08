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
        [Route("api/personCreditCards")]
        [ApiVersion("1.0")]
        public class PersonCreditCardController: AbstractPersonCreditCardController
        {
                public PersonCreditCardController(
                        ServiceSettings settings,
                        ILogger<PersonCreditCardController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPersonCreditCardService personCreditCardService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               personCreditCardService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c37d083030c3556beec1a83672e82898</Hash>
</Codenesium>*/