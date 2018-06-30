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
        [Route("api/communityActionTemplates")]
        [ApiVersion("1.0")]
        public class CommunityActionTemplateController : AbstractCommunityActionTemplateController
        {
                public CommunityActionTemplateController(
                        ApiSettings settings,
                        ILogger<CommunityActionTemplateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICommunityActionTemplateService communityActionTemplateService,
                        IApiCommunityActionTemplateModelMapper communityActionTemplateModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               communityActionTemplateService,
                               communityActionTemplateModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>75cc390d0221d4a8a68d598afdd7c65e</Hash>
</Codenesium>*/