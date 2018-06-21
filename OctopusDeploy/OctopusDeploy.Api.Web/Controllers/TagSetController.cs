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
        [Route("api/tagSets")]
        [ApiVersion("1.0")]
        public class TagSetController : AbstractTagSetController
        {
                public TagSetController(
                        ApiSettings settings,
                        ILogger<TagSetController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITagSetService tagSetService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               tagSetService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>2f0f64ccb7ff64b5ceb33df4ffb435d2</Hash>
</Codenesium>*/