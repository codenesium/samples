using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Web
{
        [Route("api/files")]
        [ApiVersion("1.0")]
        public class FileController: AbstractFileController
        {
                public FileController(
                        ApiSettings settings,
                        ILogger<FileController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IFileService fileService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               fileService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>82b16f364b0860cd86b247556235233a</Hash>
</Codenesium>*/