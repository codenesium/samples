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
        [ApiVersion("1.0")]
        public class PenController : AbstractPenController
        {
                public PenController(
                        ApiSettings settings,
                        ILogger<PenController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPenService penService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               penService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>23d298d3d51998a232515ff0f4a053cb</Hash>
</Codenesium>*/