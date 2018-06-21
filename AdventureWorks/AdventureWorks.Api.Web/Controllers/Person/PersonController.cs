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
        [Route("api/people")]
        [ApiVersion("1.0")]
        public class PersonController : AbstractPersonController
        {
                public PersonController(
                        ApiSettings settings,
                        ILogger<PersonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPersonService personService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               personService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>56867db9c7475fc0d1bd9b71e74184f7</Hash>
</Codenesium>*/