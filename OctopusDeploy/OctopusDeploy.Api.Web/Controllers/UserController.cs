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
        [Route("api/users")]
        [ApiVersion("1.0")]
        public class UserController: AbstractUserController
        {
                public UserController(
                        ApiSettings settings,
                        ILogger<UserController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IUserService userService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               userService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>969b69c2befcf9ca56dbc97c4d56d7cf</Hash>
</Codenesium>*/