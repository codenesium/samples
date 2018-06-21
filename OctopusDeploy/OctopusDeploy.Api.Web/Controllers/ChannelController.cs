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
        [Route("api/channels")]
        [ApiVersion("1.0")]
        public class ChannelController : AbstractChannelController
        {
                public ChannelController(
                        ApiSettings settings,
                        ILogger<ChannelController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IChannelService channelService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               channelService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f3dc2ee5a7d6eca27fc8691cf3ea6261</Hash>
</Codenesium>*/