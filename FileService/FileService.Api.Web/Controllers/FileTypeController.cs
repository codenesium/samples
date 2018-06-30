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
                        IFileTypeService fileTypeService,
                        IApiFileTypeModelMapper fileTypeModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               fileTypeService,
                               fileTypeModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9e1ed05be9f2f86931e8e36110a97fe5</Hash>
</Codenesium>*/