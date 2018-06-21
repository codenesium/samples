using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/admins")]
        [ApiVersion("1.0")]
        public class AdminController : AbstractAdminController
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
    <Hash>db464477c68cc2401d0c625d36212d29</Hash>
</Codenesium>*/