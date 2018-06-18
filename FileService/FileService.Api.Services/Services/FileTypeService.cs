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
                        ILogger<IFileTypeRepository> logger,
                        IFileTypeRepository fileTypeRepository,
                        IApiFileTypeRequestModelValidator fileTypeModelValidator,
                        IBOLFileTypeMapper bolfileTypeMapper,
                        IDALFileTypeMapper dalfileTypeMapper
                        ,
                        IBOLFileMapper bolFileMapper,
                        IDALFileMapper dalFileMapper

                        )
                        : base(logger,
                               fileTypeRepository,
                               fileTypeModelValidator,
                               bolfileTypeMapper,
                               dalfileTypeMapper
                               ,
                               bolFileMapper,
                               dalFileMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f7ef59a558136940bbcce44325e98748</Hash>
</Codenesium>*/