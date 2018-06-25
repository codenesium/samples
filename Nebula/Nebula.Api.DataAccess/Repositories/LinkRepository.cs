using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public partial class LinkRepository : AbstractLinkRepository, ILinkRepository
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
    <Hash>cf5accfa3f3e5d54f37c74b95003bf73</Hash>
</Codenesium>*/