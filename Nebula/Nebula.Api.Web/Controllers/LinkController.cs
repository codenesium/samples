using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Web
{
        [Route("api/links")]
        [ApiVersion("1.0")]
        public class LinkController: AbstractLinkController
        {
                public LinkController(
                        ServiceSettings settings,
                        ILogger<LinkController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILinkService linkService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               linkService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1563bfdcaad0b86235e4c30f33a1d715</Hash>
</Codenesium>*/