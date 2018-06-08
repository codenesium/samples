using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public class FileRepository: AbstractFileRepository, IFileRepository
        {
                public FileRepository(
                        ILogger<FileRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e4d9960518e8a6771590cefaefc1beb2</Hash>
</Codenesium>*/