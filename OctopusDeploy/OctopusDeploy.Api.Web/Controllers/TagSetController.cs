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
                        ITagSetService tagSetService,
                        IApiTagSetModelMapper tagSetModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               tagSetService,
                               tagSetModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e8ae900f86bdee3d584f701d7bd7facf</Hash>
</Codenesium>*/