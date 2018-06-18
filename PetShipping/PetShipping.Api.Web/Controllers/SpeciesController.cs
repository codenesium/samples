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
        [Route("api/species")]
        [ApiVersion("1.0")]
        public class SpeciesController: AbstractSpeciesController
        {
                public SpeciesController(
                        ApiSettings settings,
                        ILogger<SpeciesController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpeciesService speciesService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               speciesService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d32b2e30e11b9d74200ff02858a0889e</Hash>
</Codenesium>*/