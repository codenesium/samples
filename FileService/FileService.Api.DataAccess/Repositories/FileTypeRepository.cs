using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public class FileTypeRepository: AbstractFileTypeRepository, IFileTypeRepository
        {
                public FileTypeRepository(
                        ILogger<FileTypeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4dcddce15fdafffb7e7c57ca55531523</Hash>
</Codenesium>*/