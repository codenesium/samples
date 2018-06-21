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
        [Route("api/emailAddresses")]
        [ApiVersion("1.0")]
        public class EmailAddressController : AbstractEmailAddressController
        {
                public EmailAddressController(
                        ApiSettings settings,
                        ILogger<EmailAddressController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmailAddressService emailAddressService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               emailAddressService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>4774afc1f6a53d91a63ae84c359ea0cb</Hash>
</Codenesium>*/