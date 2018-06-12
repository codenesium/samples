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
                        ServiceSettings settings,
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
    <Hash>d9e8b664c159dd223816c3c6712e2457</Hash>
</Codenesium>*/