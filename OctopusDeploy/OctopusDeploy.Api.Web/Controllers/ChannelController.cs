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
        [Route("api/channels")]
        [ApiVersion("1.0")]
        public class ChannelController: AbstractChannelController
        {
                public ChannelController(
                        ServiceSettings settings,
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
    <Hash>6ea3991bbda6d8a3b06dbb912f993bc1</Hash>
</Codenesium>*/