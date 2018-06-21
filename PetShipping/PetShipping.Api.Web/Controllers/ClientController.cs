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
        [Route("api/clients")]
        [ApiVersion("1.0")]
        public class ClientController : AbstractClientController
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
    <Hash>c565305520e531192fb7d138ac399ebe</Hash>
</Codenesium>*/