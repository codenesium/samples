using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileServiceNS.Api.Web
{
        [Route("api/files")]
        [ApiController]
        [ApiVersion("1.0")]
        public class FileController : AbstractFileController
        {
                public FileController(
                        ApiSettings settings,
                        ILogger<FileController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IFileService fileService,
                        IApiFileModelMapper fileModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               fileService,
                               fileModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>59afb15d348d9a89a2b069b997d11baf</Hash>
</Codenesium>*/