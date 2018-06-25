using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public partial class LinkStatusRepository : AbstractLinkStatusRepository, ILinkStatusRepository
        {
                public LinkStatusRepository(
                        ILogger<LinkStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>50af051c0d8c62a5ae90759e0b5c3b5b</Hash>
</Codenesium>*/