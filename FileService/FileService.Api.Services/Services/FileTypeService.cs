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
        public class FileTypeService: AbstractFileTypeService, IFileTypeService
        {
                public FileTypeService(
                        ILogger<FileTypeRepository> logger,
                        IFileTypeRepository fileTypeRepository,
                        IApiFileTypeRequestModelValidator fileTypeModelValidator,
                        IBOLFileTypeMapper bolfileTypeMapper,
                        IDALFileTypeMapper dalfileTypeMapper)
                        : base(logger,
                               fileTypeRepository,
                               fileTypeModelValidator,
                               bolfileTypeMapper,
                               dalfileTypeMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f2e8fc83ad55228c6fe850b974f4e857</Hash>
</Codenesium>*/