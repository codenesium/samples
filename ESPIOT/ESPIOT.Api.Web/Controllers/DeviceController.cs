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
        [Route("api/devices")]
        [ApiVersion("1.0")]
        public class DeviceController : AbstractDeviceController
        {
                public DeviceController(
                        ApiSettings settings,
                        ILogger<DeviceController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeviceService deviceService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               deviceService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d83909c7644db4d18091b6d2642859cd</Hash>
</Codenesium>*/