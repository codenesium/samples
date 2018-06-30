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
                        IPersonService personService,
                        IApiPersonModelMapper personModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               personService,
                               personModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f669d4fa11100b9355195c60fbe46278</Hash>
</Codenesium>*/