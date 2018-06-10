using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/admins")]
        [ApiVersion("1.0")]
        public class AdminController: AbstractAdminController
        {
                public AdminController(
                        ServiceSettings settings,
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
    <Hash>681bf0666bc287ffbbca545c26fa2416</Hash>
</Codenesium>*/