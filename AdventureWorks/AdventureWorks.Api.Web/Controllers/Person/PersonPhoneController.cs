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
        [Route("api/personPhones")]
        [ApiVersion("1.0")]
        public class PersonPhoneController: AbstractPersonPhoneController
        {
                public PersonPhoneController(
                        ApiSettings settings,
                        ILogger<PersonPhoneController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPersonPhoneService personPhoneService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               personPhoneService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e4050dc40e7ff64303400d90adac4a70</Hash>
</Codenesium>*/