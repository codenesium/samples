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
    <Hash>69337ac0d1336aef2f70fa44440349aa</Hash>
</Codenesium>*/