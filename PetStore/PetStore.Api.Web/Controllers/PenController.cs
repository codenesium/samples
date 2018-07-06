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
        [Route("api/pens")]
        [ApiController]
        [ApiVersion("1.0")]
        public class PenController : AbstractPenController
        {
                public PenController(
                        ApiSettings settings,
                        ILogger<PenController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPenService penService,
                        IApiPenModelMapper penModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               penService,
                               penModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d0fec2737246db6320ee858861018a5a</Hash>
</Codenesium>*/