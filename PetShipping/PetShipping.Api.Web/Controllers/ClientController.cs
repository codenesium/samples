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
        [Route("api/clients")]
        [ApiVersion("1.0")]
        public class ClientController: AbstractClientController
        {
                public ClientController(
                        ApiSettings settings,
                        ILogger<ClientController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IClientService clientService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               clientService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>676119682e50123121d314beb031539c</Hash>
</Codenesium>*/