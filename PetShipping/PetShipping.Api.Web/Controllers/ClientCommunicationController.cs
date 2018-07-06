using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Web
{
        [Route("api/clientCommunications")]
        [ApiController]
        [ApiVersion("1.0")]
        public class ClientCommunicationController : AbstractClientCommunicationController
        {
                public ClientCommunicationController(
                        ApiSettings settings,
                        ILogger<ClientCommunicationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IClientCommunicationService clientCommunicationService,
                        IApiClientCommunicationModelMapper clientCommunicationModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               clientCommunicationService,
                               clientCommunicationModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>506a32fa09fea9264d50453a5ea8630b</Hash>
</Codenesium>*/