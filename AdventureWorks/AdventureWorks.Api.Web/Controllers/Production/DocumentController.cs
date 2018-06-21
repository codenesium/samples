using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/documents")]
        [ApiVersion("1.0")]
        public class DocumentController : AbstractDocumentController
        {
                public DocumentController(
                        ApiSettings settings,
                        ILogger<DocumentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDocumentService documentService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               documentService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>60110e6e4a8646ea9a7a3a0b64531d4d</Hash>
</Codenesium>*/