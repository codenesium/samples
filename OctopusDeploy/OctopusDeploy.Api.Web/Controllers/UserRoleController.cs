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
        [Route("api/userRoles")]
        [ApiVersion("1.0")]
        public class UserRoleController : AbstractUserRoleController
        {
                public UserRoleController(
                        ApiSettings settings,
                        ILogger<UserRoleController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IUserRoleService userRoleService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               userRoleService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>084996805899c8eeab9ebd27f3682cf0</Hash>
</Codenesium>*/