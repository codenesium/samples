using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/documents")]
        [ApiVersion("1.0")]
        public class DocumentController: AbstractDocumentController
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
    <Hash>a3b9e4a30ae3f85856bcae3319caae04</Hash>
</Codenesium>*/