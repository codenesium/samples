using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/eventRelatedDocuments")]
        [ApiVersion("1.0")]
        public class EventRelatedDocumentController: AbstractEventRelatedDocumentController
        {
                public EventRelatedDocumentController(
                        ApiSettings settings,
                        ILogger<EventRelatedDocumentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEventRelatedDocumentService eventRelatedDocumentService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               eventRelatedDocumentService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>dd7b20fe20a8c85dcc51628e59853457</Hash>
</Codenesium>*/