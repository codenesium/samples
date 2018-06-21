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
        [Route("api/passwords")]
        [ApiVersion("1.0")]
        public class PasswordController : AbstractPasswordController
        {
                public PasswordController(
                        ApiSettings settings,
                        ILogger<PasswordController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPasswordService passwordService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               passwordService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>be41c5a223fd824cd1b594e2f381acb4</Hash>
</Codenesium>*/