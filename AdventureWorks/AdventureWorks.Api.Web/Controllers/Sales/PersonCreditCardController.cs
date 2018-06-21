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
        [Route("api/personCreditCards")]
        [ApiVersion("1.0")]
        public class PersonCreditCardController : AbstractPersonCreditCardController
        {
                public PersonCreditCardController(
                        ApiSettings settings,
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
    <Hash>1576f30bc0e20b647c98cac178d6f1ae</Hash>
</Codenesium>*/