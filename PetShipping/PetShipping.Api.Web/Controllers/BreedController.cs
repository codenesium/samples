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
        [Route("api/breeds")]
        [ApiVersion("1.0")]
        public class BreedController : AbstractBreedController
        {
                public BreedController(
                        ApiSettings settings,
                        ILogger<BreedController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBreedService breedService,
                        IApiBreedModelMapper breedModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               breedService,
                               breedModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1b7bf018ef940484289df3eb7026075d</Hash>
</Codenesium>*/