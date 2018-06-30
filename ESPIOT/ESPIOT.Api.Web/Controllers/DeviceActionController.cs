using Codenesium.Foundation.CommonMVC;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESPIOTNS.Api.Web
{
        [Route("api/deviceActions")]
        [ApiVersion("1.0")]
        public class DeviceActionController : AbstractDeviceActionController
        {
                public DeviceActionController(
                        ApiSettings settings,
                        ILogger<DeviceActionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeviceActionService deviceActionService,
                        IApiDeviceActionModelMapper deviceActionModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               deviceActionService,
                               deviceActionModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ca121b2a84b82f55b4317b5b96af57bf</Hash>
</Codenesium>*/