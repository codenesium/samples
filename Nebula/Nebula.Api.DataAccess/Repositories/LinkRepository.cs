using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkRepository : AbstractLinkRepository, ILinkRepository
        {
                public LinkRepository(
                        ILogger<LinkRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>06a7f6f4e001ab3974ce63e4ea8a535a</Hash>
</Codenesium>*/