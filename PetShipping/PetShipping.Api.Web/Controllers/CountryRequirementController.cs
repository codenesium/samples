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
        [Route("api/countryRequirements")]
        [ApiVersion("1.0")]
        public class CountryRequirementController : AbstractCountryRequirementController
        {
                public CountryRequirementController(
                        ApiSettings settings,
                        ILogger<CountryRequirementController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICountryRequirementService countryRequirementService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               countryRequirementService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>041e1f36c7e3286124f7075a0d869442</Hash>
</Codenesium>*/