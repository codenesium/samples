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
        [Route("api/countryRequirements")]
        [ApiVersion("1.0")]
        public class CountryRequirementController: AbstractCountryRequirementController
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
    <Hash>fde768c13f4d5674cbac6b7584fe0391</Hash>
</Codenesium>*/