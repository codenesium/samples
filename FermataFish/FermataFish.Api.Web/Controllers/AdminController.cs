using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Web
{
        [Route("api/admins")]
        [ApiController]
        [ApiVersion("1.0")]
        public class AdminController : AbstractAdminController
        {
                public AdminController(
                        ApiSettings settings,
                        ILogger<AdminController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAdminService adminService,
                        IApiAdminModelMapper adminModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               adminService,
                               adminModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>43a6aa90895cb9996ea4ecd557345c59</Hash>
</Codenesium>*/