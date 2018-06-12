using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/accounts")]
        [ApiVersion("1.0")]
        public class AccountController: AbstractAccountController
        {
                public AccountController(
                        ServiceSettings settings,
                        ILogger<AccountController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAccountService accountService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               accountService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0b3e90113326f88a1613a34c344ecfdb</Hash>
</Codenesium>*/