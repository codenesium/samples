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
        [Route("api/tagSets")]
        [ApiVersion("1.0")]
        public class TagSetController: AbstractTagSetController
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
    <Hash>c5c5a3b85437b81fd2bb910f6a4da264</Hash>
</Codenesium>*/