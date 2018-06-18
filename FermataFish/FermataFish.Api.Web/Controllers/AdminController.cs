using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Web
{
        [Route("api/admins")]
        [ApiVersion("1.0")]
        public class AdminController: AbstractAdminController
        {
                public AdminController(
                        ApiSettings settings,
                        ILogger<AdminController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAdminService adminService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               adminService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c8efe45e0e5dfa0f11698861a5808552</Hash>
</Codenesium>*/