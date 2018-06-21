using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowNS.Api.Web
{
        [Route("api/users")]
        [ApiVersion("1.0")]
        public class UsersController : AbstractUsersController
        {
                public UsersController(
                        ApiSettings settings,
                        ILogger<UsersController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IUsersService usersService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               usersService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>2e1c7ab35d1fda1578e44e4740b97ed1</Hash>
</Codenesium>*/