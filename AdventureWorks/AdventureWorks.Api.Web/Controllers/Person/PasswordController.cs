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
        [Route("api/passwords")]
        [ApiVersion("1.0")]
        public class PasswordController: AbstractPasswordController
        {
                public PasswordController(
                        ServiceSettings settings,
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
    <Hash>046dd691493c26c4cffef362813b55a7</Hash>
</Codenesium>*/