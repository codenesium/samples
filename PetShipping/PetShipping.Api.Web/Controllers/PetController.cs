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
        [Route("api/pets")]
        [ApiVersion("1.0")]
        public class PetController : AbstractPetController
        {
                public PetController(
                        ApiSettings settings,
                        ILogger<PetController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPetService petService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               petService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>2dafd14530dec9a0b3e8b20bd2cd562b</Hash>
</Codenesium>*/