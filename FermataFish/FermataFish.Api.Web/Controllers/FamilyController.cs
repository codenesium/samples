using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Web
{
        [Route("api/families")]
        [ApiVersion("1.0")]
        public class FamilyController: AbstractFamilyController
        {
                public FamilyController(
                        ServiceSettings settings,
                        ILogger<FamilyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IFamilyService familyService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               familyService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b9985259f0e9c862183b51a4b9733852</Hash>
</Codenesium>*/