using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStoreNS.Api.Web
{
        [Route("api/species")]
        [ApiVersion("1.0")]
        public class SpeciesController : AbstractSpeciesController
        {
                public SpeciesController(
                        ApiSettings settings,
                        ILogger<SpeciesController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpeciesService speciesService,
                        IApiSpeciesModelMapper speciesModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               speciesService,
                               speciesModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9f6d3e7034aa17174166488f2a021379</Hash>
</Codenesium>*/