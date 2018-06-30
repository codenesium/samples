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
        [Route("api/pets")]
        [ApiVersion("1.0")]
        public class PetController : AbstractPetController
        {
                public PetController(
                        ApiSettings settings,
                        ILogger<PetController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPetService petService,
                        IApiPetModelMapper petModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               petService,
                               petModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>22cba818b338b39ba3805e8a6af97ac1</Hash>
</Codenesium>*/