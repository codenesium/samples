using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileServiceNS.Api.Web
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
    <Hash>3b637a27c0735dd61eb0f10cd6f76c09</Hash>
</Codenesium>*/