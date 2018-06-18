using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Web
{
        [Route("api/pens")]
        [ApiVersion("1.0")]
        public class PenController: AbstractPenController
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
    <Hash>5f884b1cc2a544cf1158efec8d70adab</Hash>
</Codenesium>*/