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
                               dalfileMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>1e2135cb5aadd53b11bdbad1f76000c4</Hash>
</Codenesium>*/