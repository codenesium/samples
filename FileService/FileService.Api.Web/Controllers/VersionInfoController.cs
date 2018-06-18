using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Web
{
        [Route("api/versionInfoes")]
        [ApiVersion("1.0")]
        public class VersionInfoController: AbstractVersionInfoController
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
    <Hash>9f71003152ae7c807f57a7ac494b81f5</Hash>
</Codenesium>*/