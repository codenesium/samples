using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public partial class FileRepository : AbstractFileRepository, IFileRepository
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
    <Hash>4d161b0fcb50ef6078039e8015b4d3b2</Hash>
</Codenesium>*/