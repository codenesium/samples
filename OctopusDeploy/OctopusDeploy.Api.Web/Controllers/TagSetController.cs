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
        [ApiController]
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
    <Hash>cbf708fd82d708749a4333da28972c10</Hash>
</Codenesium>*/