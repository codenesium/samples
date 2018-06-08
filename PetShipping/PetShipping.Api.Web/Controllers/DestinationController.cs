using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Web
{
        [Route("api/destinations")]
        [ApiVersion("1.0")]
        public class DestinationController: AbstractDestinationController
        {
                public DestinationController(
                        ServiceSettings settings,
                        ILogger<DestinationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDestinationService destinationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               destinationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>4bf646cedb825b51607d734cf4db1686</Hash>
</Codenesium>*/