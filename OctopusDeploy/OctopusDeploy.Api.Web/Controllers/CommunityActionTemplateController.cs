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
        [Route("api/communityActionTemplates")]
        [ApiVersion("1.0")]
        public class CommunityActionTemplateController: AbstractCommunityActionTemplateController
        {
                public CommunityActionTemplateController(
                        ApiSettings settings,
                        ILogger<CommunityActionTemplateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICommunityActionTemplateService communityActionTemplateService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               communityActionTemplateService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0862717bf6b439d369350e5378352fa7</Hash>
</Codenesium>*/