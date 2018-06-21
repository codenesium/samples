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
        [Route("api/invitations")]
        [ApiVersion("1.0")]
        public class InvitationController : AbstractInvitationController
        {
                public InvitationController(
                        ApiSettings settings,
                        ILogger<InvitationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IInvitationService invitationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               invitationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ce3021cecfecb859f93bce864f695edd</Hash>
</Codenesium>*/