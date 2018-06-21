using Codenesium.DataConversionExtensions.AspNetCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Services
{
        public class FileService : AbstractFileService, IFileService
        {
                public FileService(
                        ILogger<IFileRepository> logger,
                        IFileRepository fileRepository,
                        IApiFileRequestModelValidator fileModelValidator,
                        IBOLFileMapper bolfileMapper,
                        IDALFileMapper dalfileMapper
                        )
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
    <Hash>5128c41f6cb382451b2d1b62114d14b3</Hash>
</Codenesium>*/