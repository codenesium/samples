using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkLogRepository : AbstractLinkLogRepository, ILinkLogRepository
        {
                public LinkLogRepository(
                        ILogger<LinkLogRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b793f9ff6e0904e44a94bf6432341756</Hash>
</Codenesium>*/