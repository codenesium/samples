using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/eventRelatedDocuments")]
        [ApiVersion("1.0")]
        public class EventRelatedDocumentController : AbstractEventRelatedDocumentController
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
    <Hash>0d8048ac7601e05e1160f9620f671632</Hash>
</Codenesium>*/