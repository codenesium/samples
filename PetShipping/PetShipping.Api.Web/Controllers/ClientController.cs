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
                        ServiceSettings settings,
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
    <Hash>0b4f892ee88b60d75d2113ce4c312b34</Hash>
</Codenesium>*/