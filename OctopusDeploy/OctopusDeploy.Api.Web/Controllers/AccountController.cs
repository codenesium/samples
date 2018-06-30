using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/accounts")]
        [ApiVersion("1.0")]
        public class AccountController : AbstractAccountController
        {
                public AccountController(
                        ApiSettings settings,
                        ILogger<AccountController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAccountService accountService,
                        IApiAccountModelMapper accountModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               accountService,
                               accountModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b61b027d12705f541d235a0ec892e7ab</Hash>
</Codenesium>*/