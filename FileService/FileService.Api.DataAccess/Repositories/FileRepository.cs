using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public class FileRepository : AbstractFileRepository, IFileRepository
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
    <Hash>097a66c6b1d4b253b12dd45dfbd792cd</Hash>
</Codenesium>*/