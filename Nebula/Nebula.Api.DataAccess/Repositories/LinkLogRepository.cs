using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkLogRepository: AbstractLinkLogRepository, ILinkLogRepository
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
    <Hash>7a7d80f8742c43db246ce5f90feb04dd</Hash>
</Codenesium>*/