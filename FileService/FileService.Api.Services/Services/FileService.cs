using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class FileService: AbstractFileService, IFileService
        {
                public FileService(
                        ILogger<FileRepository> logger,
                        IFileRepository fileRepository,
                        IApiFileRequestModelValidator fileModelValidator,
                        IBOLFileMapper bolfileMapper,
                        IDALFileMapper dalfileMapper)
                        : base(logger,
                               fileRepository,
                               fileModelValidator,
                               bolfileMapper,
                               dalfileMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8e14d5676f1db2fe867ff1d68654e77f</Hash>
</Codenesium>*/