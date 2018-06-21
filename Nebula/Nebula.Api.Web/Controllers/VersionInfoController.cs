using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NebulaNS.Api.Web
{
        [Route("api/versionInfoes")]
        [ApiVersion("1.0")]
        public class VersionInfoController : AbstractVersionInfoController
        {
                public VersionInfoController(
                        ApiSettings settings,
                        ILogger<VersionInfoController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVersionInfoService versionInfoService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               versionInfoService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a7fb6ad4f04962b456082880b91b95cd</Hash>
</Codenesium>*/