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
        [Route("api/breeds")]
        [ApiVersion("1.0")]
        public class BreedController: AbstractBreedController
        {
                public BreedController(
                        ApiSettings settings,
                        ILogger<BreedController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBreedService breedService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               breedService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a149909a5bdb2262ecdaf8541973780d</Hash>
</Codenesium>*/