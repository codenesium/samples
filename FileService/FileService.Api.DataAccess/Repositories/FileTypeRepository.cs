using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public class FileTypeRepository : AbstractFileTypeRepository, IFileTypeRepository
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
    <Hash>fdbbc8246b5ce48d3dfc879fb6ac74d8</Hash>
</Codenesium>*/