using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Web
{
        [Route("api/families")]
        [ApiVersion("1.0")]
        public class FamilyController : AbstractFamilyController
        {
                public FamilyController(
                        ApiSettings settings,
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
    <Hash>0f4378b88628d7df81e73b41244c0c1b</Hash>
</Codenesium>*/