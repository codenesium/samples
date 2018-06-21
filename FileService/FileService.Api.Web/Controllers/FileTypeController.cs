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
        [Route("api/fileTypes")]
        [ApiVersion("1.0")]
        public class FileTypeController : AbstractFileTypeController
        {
                public FileTypeController(
                        ApiSettings settings,
                        ILogger<FileTypeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IFileTypeService fileTypeService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               fileTypeService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7ef1bb3eae53667ce20da65e7cb994aa</Hash>
</Codenesium>*/