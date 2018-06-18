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
        [Route("api/clientCommunications")]
        [ApiVersion("1.0")]
        public class ClientCommunicationController: AbstractClientCommunicationController
        {
                public ClientCommunicationController(
                        ApiSettings settings,
                        ILogger<ClientCommunicationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IClientCommunicationService clientCommunicationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               clientCommunicationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b3b02dbfac361e645548888f7f82e0f6</Hash>
</Codenesium>*/